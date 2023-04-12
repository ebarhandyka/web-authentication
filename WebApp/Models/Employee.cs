using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_M_Employees")]
    [Microsoft.EntityFrameworkCore.Index("Email", IsUnique = true)]
    public class Employee
    {
        [Key]
        [Column("nik", TypeName = "CHAR(5)")]
        public string NIK { get; set; }
        [Column("first_name", TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }
        [Column("last_name", TypeName = "VARCHAR(50)")]
        public string? LastName { get; set; }
        [Column("birth_date", TypeName = "DATETIME")]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        public Gender Gender { get; set; }
        [Column("hiring_date", TypeName = "DATETIME")]
        public DateTime HiringDate { get; set; }
        [Column("email", TypeName = "VARCHAR(50)")]
        public string Email { get; set; }
        [Column("phone_number", TypeName = "VARCHAR(20)")]
        public string PhoneNumber { get; set; }

        //Cardinality
        public Account? Accounts { get; set; }
        public Profiling? Profilings { get; set; }
    }
    public enum Gender
    {
        Male, Famale
    }
}
