﻿using Physiotherapy.Common._Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Physiotherapy.Model
{
    [Table("Education", Schema = "CV")]
    public class EducationVO
    {
        [Key]
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

        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        [Column("StartDate", Order = 4)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "GraduationDate", ResourceType = typeof(Resource))]
        [Column("GraduationDate", Order = 5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Date)]
        public DateTime GraduationDate { get; set; }

        [Display(Name = "Grade", ResourceType = typeof(Resource))]
        [Column("Grade", Order = 6)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public Decimal Grade { get; set; }

        [Column("CreatedDate", Order = 11)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public DateTime CreatedDate { get; set; }

        [Column("ModifiedBy", Order = 12)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resource))]
        public DateTime ModifiedBy { get; set; }

        [Required]
        [Column("MemberId", Order = 100)]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual MemberVO Member { get; set; }
    }
}