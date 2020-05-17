using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("Phone", Schema = "Person")]
    public partial class PhoneVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column("Phone", TypeName = "nvarchar", Order = 1)]
        public string Phone { get; set; }

        [Column("CodeCountry", TypeName = "nvarchar", Order = 2)]
        public string CodeCountry { get; set; }

        [Column("IsMobile", TypeName = "bit", Order = 3)]
        public bool IsMobile { get; set; }

        public virtual int PersonId { get; set; }

        [ForeignKey("PersonId")]
        [Column("PersonId", Order = 100)]
        public virtual PersonVO Person { get; set; }
    }
}