using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Physiotherapy.Common._Resources;

namespace Physiotherapy.Model
{
    [Table("Address",Schema = "Person")]
    public partial class AddressVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resource))]
        [Column("City", TypeName = "nvarchar", Order = 5)]
        [MaxLength(50)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string City { get; set; }

        [Column("Street", TypeName = "nvarchar", Order = 1)]
        [MaxLength(100)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Street { get; set; }


        [Column("Country", TypeName= "nvarchar", Order = 4)]
        [MaxLength(50)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Country { get; set; }

        [Column("PostCode", TypeName = "nvarchar", Order = 3)]
        [MaxLength(5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string PostCode { get; set; }

        [Column("Number", TypeName = "nvarchar", Order = 2)]
        [MaxLength(5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Number { get; set; }


        public virtual int PersonId { get; set; }

        [ForeignKey("PersonId")]
        [Column("PersonId", Order = 100)]
        public virtual PersonVO Person { get; set; }
    }
}
