using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Repositories.Data
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
        public UniversityRepository(MyContext context) : base(context)
        {
        }
    }
}
