using Api.TheSill.src.common.helpers;

namespace Api.TheSill.src.repositories
{
    public interface IRoleService
    {
       Task< Response<string>> Save();
    }
}