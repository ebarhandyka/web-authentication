using WebApp.Models;

namespace WebApp.Repositories.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
    }
}
