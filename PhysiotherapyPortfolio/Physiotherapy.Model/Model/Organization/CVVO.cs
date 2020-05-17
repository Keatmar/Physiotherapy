using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("CV", Schema = "Organization")]
    public partial class CvVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column("MemberId", Order = 100)]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual MemberVO Member { get; set; }
    }
}