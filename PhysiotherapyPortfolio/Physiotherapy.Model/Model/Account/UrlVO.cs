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
    [Table("Url")]
    public class UrlVO
    {
        [Key]
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Url", ResourceType = typeof(Resource))]
        [Column("Url", Order = 1)]
        public string Url{ get; set; }

        [Display(Name = "From", ResourceType = typeof(Resource))]
        [Column("CreationDate", Order = 2, TypeName = "Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "To", ResourceType = typeof(Resource))]
        [Column("ExpireDate", Order = 3, TypeName = "Date")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "UniqueKey", ResourceType = typeof(Resource))]
        [Column("GUID", Order = 4)]
        public string GUID{ get; set; }

    }
}
