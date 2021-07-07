using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IChartDal
    {
        
        List<CategoryChartViewModel> List1();
        List<ContentChartViewModel> List2();
        List<HeadingChartViewModel> List3();
    }
}
