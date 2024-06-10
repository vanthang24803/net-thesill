using Api.TheSill.src.common.helpers;
using Api.TheSill.src.repositories;

namespace Api.TheSill.src.services
{
    public class RoleService : IRoleService
    {
        public async Task<Response<string>> Save()
        {
            return new Response<string> { Status = 200, Result = "Hello World" };
        }
    }
}