using WebApp.Contexts;
using WebApp.Models;
using WebApp.Repositories.Contracts;
using WebApp.ViewModels;

namespace WebApp.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
    {
        public AccountRepository(MyContext context) : base(context) { }
        public int Register(RegisterVM registerVM)
        {

            var university = new University
            {
                Name = registerVM.UniversityName,
            };
            _context.Universities.Add(university);
            _context.SaveChanges();

            var education = new Education
            {
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityID = university.ID,
            };
            _context.Educations.Add(education);
            _context.SaveChanges();

            var employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                PhoneNumber = registerVM.PhoneNumber,
                Email = registerVM.Email,
                HiringDate = DateTime.Now,
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var account = new Account
            {
                EmployeeNIK = registerVM.NIK,
                Password = registerVM.Password,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var profiling = new Profiling
            {
                EmployeeNIK = registerVM.NIK,
                EducationID = education.ID,
            };
            _context.Profilings.Add(profiling);
            return _context.SaveChanges();

        }
        public int Login(LoginVM loginVM)
        {
            var university = new University
            {
            };
            _context.Universities.Add(university);
            _context.SaveChanges();

            var education = new Education
            {
                UniversityID = university.ID,
            };
            _context.Educations.Add(education);
            _context.SaveChanges();

            var employee = new Employee
            {
                Email = loginVM.Email,
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var account = new Account
            {
                Password = loginVM.Password,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var profiling = new Profiling
            {
                EmployeeNIK = employee.NIK,
                EducationID = education.ID,
            };

            _context.Profilings.Add(profiling);
            return _context.SaveChanges();
        }
    }
}
