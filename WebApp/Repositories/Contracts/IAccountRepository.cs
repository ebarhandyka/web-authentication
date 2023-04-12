using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Repositories.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        int Register(RegisterVM registerVM);
        int Login(LoginVM loginVM);
    }
}
