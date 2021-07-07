using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
        [StringLength(100)]
        public string RoleDetails { get; set; }       
        public bool RoleStatus { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }

}
