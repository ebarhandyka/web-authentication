using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        [Column("employee_nik", TypeName = "CHAR (5)")]
        public string EmployeeNIK { get; set; }
        [Column("password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }

        //Cardinality
        public Employee? Employees { get; set; }
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }

}
