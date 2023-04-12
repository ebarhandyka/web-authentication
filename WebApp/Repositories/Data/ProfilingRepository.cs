using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Repositories.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
