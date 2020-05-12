using Physiotherapy.Common;
using Physiotherapy.Common._Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("Person", Schema = "Person")]
    public partial class PersonVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        
        [Column("FirstName_en", TypeName = "nvarchar", Order = 1)]
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessageResourceName = "OnlyEnglishChar", ErrorMessageResourceType = typeof(Resource))]
        public string FirstName_en { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        [Column("LastName_en", TypeName = "nvarchar", Order = 2)]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessageResourceName = "OnlyEnglishChar", ErrorMessageResourceType = typeof(Resource))]
        public string LastName_en { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [Column("FirstName_el", TypeName = "nvarchar", Order = 3)]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(@"^[\p{IsGreekandCoptic}]+", ErrorMessageResourceName = "OnlyGreekChar", ErrorMessageResourceType = typeof(Resource))]
        public string FirstName_el { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        [Column("LastName_el", TypeName = "nvarchar", Order = 4)]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(@"^[\p{IsGreekandCoptic}]+", ErrorMessageResourceName = "OnlyGreekChar", ErrorMessageResourceType = typeof(Resource))]
        public string LastName_el { get; set; }


        [Column("BirthDate", TypeName = "date", Order = 5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        
        [Column("CreationDate", TypeName = "datetime", Order = 6)]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public AddressVO Address { get; set; }
        [NotMapped]
        public EmailVO Email { get; set; }
        [NotMapped]
        public PhoneVO Phone { get; set; }
        [NotMapped]
        public PhoneVO Mobile { get; set; }

        public virtual List<AddressVO> Addresses { get; set; } = new List<AddressVO>();
       
        public virtual List<EmailVO> Emails { get; set; } = new List<EmailVO>();

        public virtual List<PhoneVO> Phones { get; set; } = new List<PhoneVO>();

    }
}
