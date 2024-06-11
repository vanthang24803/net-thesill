using System.Net;
using Api.TheSill.src.common.exceptions;
using Api.TheSill.src.common.helpers;
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
        private readonly IMapper _mapper;

        public RoleService(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<RoleResponse>>> SeedRole() {
            List<Role> roles = [Role.ADMIN, Role.CUSTOMER, Role.MANAGER];
            List<RoleResponse> result = [];

            foreach (Role role in roles) {
                if (ExistByName(role)) {
                    throw new BadRequestException("Role existed!");
                }

                var newRole = new RoleEntity {
                    Role = role
                };

                _context.Roles.Add(newRole);
                result.Add(_mapper.Map<RoleResponse>(newRole));
            }

            await _context.SaveChangesAsync();
            return new Response<List<RoleResponse>> { Status = HttpStatusCode.Created, Result = result };
        }


        public async Task<Response<List<RoleResponse>>> FindAll() {
            var roles = await _context.Roles.ToListAsync();

            var roleResponses = _mapper.Map<List<RoleResponse>>(roles);

            return new Response<List<RoleResponse>> { Status = HttpStatusCode.OK, Result = roleResponses };
        }


        public bool ExistByName(Role role) {
            return _context.Roles.Any(n => n.Role == role);
        }

        public async Task<RoleEntity> FindRoleByName(Role name) {
            var role = await _context.Roles.FirstOrDefaultAsync(n => n.Role == name) ?? throw new NotFoundException("Role not found");

            return role;
        }
    }
}
