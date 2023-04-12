using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_M_Educations")]
    public class Education
    {
        [Key]
        [Column("id", TypeName = "INT")]
        public int ID { get; set; }
        [Column("major", TypeName = "VARCHAR(100)")]
        public string Major { get; set; }
        [Column("degree", TypeName = "VARCHAR(10)")]
        public string Degree { get; set; }
        [Column("gpa", TypeName = "DECIMAL(3,2)")]
        public double GPA { get; set; }
        [Column("university_id", TypeName = "INT")]
        public int UniversityID { get; set; }

        //Cardinality
        public University? Universities { get; set; }
        public Profiling? Profilings { get; set; }
    }
}
