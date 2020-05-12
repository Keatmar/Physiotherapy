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
    [Table("Phone", Schema = "Person")]
    public partial class PhoneVO
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column("Phone",TypeName ="nvarchar", Order = 1)]
        //[RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessageResourceName ="PhoneFormat", ErrorMessageResourceType =typeof(Resource))]
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
