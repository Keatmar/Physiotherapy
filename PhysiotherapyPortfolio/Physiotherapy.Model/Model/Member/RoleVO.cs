using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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