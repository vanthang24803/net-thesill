using System.Net;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.helpers;
using Api.TheSill.src.common.message;
using Api.TheSill.src.context;
using Api.TheSill.src.domain.dtos.role;
using Api.TheSill.src.domain.enums;
using Api.TheSill.src.domain.models;
using Api.TheSill.src.repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Api.TheSill.src.services {
    public class RoleService : IRoleService {
        private readonly ApplicationDbContext _context;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(ApplicationDbContext context, IMapper mapper, IRoleRepository roleRepository) {
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<Response<List<RoleResponse>>> SeedRole() {
            List<Role> roles = [Role.ADMIN, Role.CUSTOMER, Role.MANAGER];
            List<RoleResponse> result = [];

            foreach (Role role in roles) {
                if (_roleRepository.ExistByName(role)) {
                    throw new BadRequestException(ErrorMessage.ROLE_EXIST);
                }

                var newRole = new RoleEntity {
                    Role = role
                };

                _context.Roles.Add(newRole);
                result.Add(_mapper.Map<RoleResponse>(newRole));
            }

            await _context.SaveChangesAsync();
            return new Response<List<RoleResponse>>(status: HttpStatusCode.Created, result: result);
        }


        public async Task<Response<List<RoleResponse>>> FindAll() {
            var roles = await _context.Roles.ToListAsync();

            var roleResponses = _mapper.Map<List<RoleResponse>>(roles);

            return new Response<List<RoleResponse>>(status: HttpStatusCode.OK, result: roleResponses);
        }
       
    }
}
