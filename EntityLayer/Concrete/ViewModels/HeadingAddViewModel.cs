using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ViewModels
{
   public class HeadingAddViewModel
    {
        public Heading Headings { get; set; }        
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Writer> Writers { get; set; }
    }
}
