using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
    {
        public RoleRepository(MyContext context) : base(context) { }
    }
}
