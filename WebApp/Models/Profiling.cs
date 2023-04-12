using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_TR_Profilings")]
    public class Profiling
    {
        [Key]
        [Column("employee_nik", TypeName = "CHAR (5)")]
        public string EmployeeNIK { get; set; }
        [Column("education_id", TypeName = "INT")]
        public int EducationID { get; set; }

        //Cardinality
        public Education? Educations { get; set; }
        public Employee? Employees { get; set; }
    }
}
