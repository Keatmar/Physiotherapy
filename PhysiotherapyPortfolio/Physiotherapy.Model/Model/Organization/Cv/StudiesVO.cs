using Physiotherapy.Common._Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Model
{
    [Table("CV", Schema = "Organization")]
    public class StudiesVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resource))]
        [Column("Title", Order = 1)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public string Title { get; set; }

        [Display(Name = "IssuedBy", ResourceType = typeof(Resource))]
        [Column("IssuedBy", Order = 2)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public string IssuedBy {get;set;}

        [Display(Name = "Category", ResourceType = typeof(Resource))]
        [Column("Category", Order = 3)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public byte Category { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resource))]
        [Column("Country", Order = 4)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public string Country { get; set; }

        [Display(Name = "GrandingDate", ResourceType = typeof(Resource))]
        [Column("GrandingDate", Order = 5)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Date)]
        public DateTime GrandingDate { get; set; }


        [Display(Name = "Duration", ResourceType = typeof(Resource))]
        [Column("Duration", Order = 6)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public byte Duration { get; set; }

        [Display(Name = "DurationUnit", ResourceType = typeof(Resource))]
        [Column("DurationUnit", Order = 7)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public byte DurationUnit { get; set; }

        [Display(Name = "Grade", ResourceType = typeof(Resource))]
        [Column("Grade", Order = 8)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public Decimal Grade { get; set; }

        [Display(Name = "EquivalenceEnactmentDate", ResourceType = typeof(Resource))]
        [Column("EquivalenceEnactmentDate", Order = 9)]
        public DateTime EquivalenceEnactmentDate { get; set; }

        [Display(Name = "EquivalenceEnactmentNumber", ResourceType = typeof(Resource))]
        [Column("EquivalenceEnactmentNumber", Order = 9)]
        [MaxLength(50, ErrorMessage = null, ErrorMessageResourceName ="", ErrorMessageResourceType = typeof(Resource))]
        public string EquivalenceEnactmentNumber { get; set; }


        [Display(Name = "EquivalenceEnactmentUnit", ResourceType = typeof(Resource))]
        [Column("EquivalenceEnactmentUnit", Order = 10)]
        [MaxLength(150, ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public string EquivalenceEnactmentUnit { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resource))]
        [Column("CreatedDate", Order = 11)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "ModifiedBy", ResourceType = typeof(Resource))]
        [Column("ModifiedBy", Order = 12)]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "", ErrorMessageResourceType = typeof(Resource))]
        public DateTime ModifiedBy { get; set; }

        [Required]
        [Column("MemberId", Order = 100)]
        public int MemberId { get; set; }


        [ForeignKey("MemberId")]
        public virtual MemberVO Member { get; set; }
    }
}
