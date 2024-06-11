using Api.TheSill.src.common.helpers;
using Api.TheSill.src.context;
using Api.TheSill.src.repositories;

namespace Api.TheSill.src.services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<string>> Save()
        {
            
            return new Response<string> { Status = 200, Result = "Hello World" };
        }

        public void SeedRole()
        {
            throw new NotImplementedException();
        }
    }
}