using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChartService
    {
        List<CategoryChartViewModel> GetList1();
        List<ContentChartViewModel> GetList2();
        List<HeadingChartViewModel> GetList3();
    }
}
