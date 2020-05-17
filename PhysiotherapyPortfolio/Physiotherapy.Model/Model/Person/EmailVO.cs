using Physiotherapy.Common._Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("Email", Schema = "Person")]
    public partial class EmailVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column("Address", TypeName = "nvarchar", Order = 1)]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Address { get; set; }

        [Column("Domain", TypeName = "nvarchar", Order = 2)]
        [MaxLength(20)]
        public string Domain { get; set; }

        [Column("Extension", TypeName = "nvarchar", Order = 3)]
        [MaxLength(5)]
        public string Extension { get; set; }

        public virtual int PersonId { get; set; }

        [ForeignKey("PersonId")]
        [Column("PersonId", Order = 100)]
        public virtual PersonVO Person { get; set; }
    }
}