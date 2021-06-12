using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Capability
    {
        [Key]
        public int CapabilityID { get; set; }
        [StringLength(100)]
        public string CapabilityName { get; set; }       
        public int CapabilityLevel { get; set; }
        public bool CapabilityStatus { get; set; }

    }
}
