using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context)
        {
        }
    }
}
