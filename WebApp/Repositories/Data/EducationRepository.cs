using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Repositories.Data
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
    {
        public EducationRepository(MyContext context) : base(context)
        {
        }
    }
}
