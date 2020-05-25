using Physiotherapy.Common._Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("Education", Schema = "CV")]
    public class EducationVO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Display(Name = "School", ResourceType = typeof(Resource))]
        [Column("School", Order = 1)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string School { get; set; }

        [Display(Name = "Degree", ResourceType = typeof(Resource))]
        [Column("Degree", Order = 2)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Degree { get; set; }

        [Display(Name = "Department", ResourceType = typeof(Resource))]
        [Column("Department", Order = 3)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Department { get; set; }

        [Display(Name = "StartYear", ResourceType = typeof(Resource))]
        [Column("StartYear", Order = 4)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string StartYear { get; set; }

        [Display(Name = "GraduationYear", ResourceType = typeof(Resource))]
        [Column("GraduationYear", Order = 5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public string GraduationYear { get; set; }

        [Display(Name = "Grade", ResourceType = typeof(Resource))]
        [Column("Grade", Order = 6)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public Decimal Grade { get; set; }

        [Column("CreatedDate", Order = 11)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public DateTime CreatedDate { get; set; }

        [Column("ModifiedBy", Order = 12)]
        public DateTime? ModifiedBy { get; set; }

        [Required]
        [Column("MemberId", Order = 100)]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual MemberVO Member { get; set; }
    }
}