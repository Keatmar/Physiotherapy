using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Physiotherapy.Common._Resources;

namespace Physiotherapy.Model
{
    [Table("Member", Schema = "Member")]
    public class MemberVO
    {
        [Key]
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Resource))]
        [Column("Username", Order = 1)]
        [Required (ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(50, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(5, ErrorMessageResourceName = "StringLenghtO", ErrorMessageResourceType = typeof(Resource))]
        public string Username { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Column("Password", Order = 2, TypeName = "nvarchar")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\d\W])|(?=.*\W)(?=.*\d))|(?=.*\W)(?=.*[A-Z])(?=.*\d)).{8,}$",
            ErrorMessageResourceName = "PasswordErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(200, ErrorMessageResourceName = "StringLenghtM", ErrorMessageResourceType = typeof(Resource))]
        [MinLength(8, ErrorMessageResourceName = "StringLenghtM", ErrorMessageResourceType = typeof(Resource))]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "PasswordDoNotMatch", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }

        [Column("DefaultCultrure", Order = 3)]
        public string DefaultCultrure { get; set; }

        [Column("CreationDate", TypeName = "datetime", Order = 50)]
        [Required]
        public DateTime CreationDate { get; set; }

        [ForeignKey("Person")]
        [Required]
        [Column("PersonId", Order = 100)]
        public int PersonId { get; set; }

        public virtual PersonVO Person { get; set; }

        [ForeignKey("Role")]
        [Required]
        [Column("RoleId", Order = 101)]
        public int RoleId { get; set; }

        public virtual RoleVO Role { get; set; }

        public string FieldsRequired()
        {
            return Resource.FieldIsRequired;
        }
    }
}
