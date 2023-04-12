using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [Table("TB_M_Roles")]
    public class Role
    {
        [Key]
        [Column("id", TypeName = "INT")]
        public int ID { get; set; }
        [Column("name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        //Cardinality
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }

}
