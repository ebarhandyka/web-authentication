using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApp.Models
{
    [Table("TB_TR_Account_Roles")]
    public class AccountRole
    {
        [Key]
        [Column("id", TypeName = "INT")]
        public int ID { get; set; }
        [Column("account_nik", TypeName = "CHAR(5)")]
        public string AccountNIK { get; set; }
        
        [Column("role_id", TypeName = "INT")]
        public int RoleID { get; set; }

        //Cardinality
        public Account? Accounts { get; set; }
        public Role? Roles { get; set; }

    }
}
