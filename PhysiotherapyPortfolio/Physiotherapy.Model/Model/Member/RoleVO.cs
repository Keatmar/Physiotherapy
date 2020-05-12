using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Physiotherapy.Model
{
    [Table("Role", Schema = "Member")]
    public class RoleVO
    {
        [Key]
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Column("Name", Order = 1)]
        [Required]
        public string Name { get; set; }


    }
}
