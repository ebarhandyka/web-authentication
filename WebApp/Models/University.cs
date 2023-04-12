using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_M_Universities")]
    public class University
    {
        [Key]
        [Column("id", TypeName = "INT")]
        public int ID { get; set; }
        [Column("name", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }
        
        //Cardinality
        public ICollection<Education> Educations { get; set; }
    }
}
