using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChartManager : IChartService
    {
        IChartDal _chartDal;

        public ChartManager(IChartDal chartDal)
        {
            _chartDal = chartDal;
        }

        
        public List<CategoryChartViewModel> GetList1()
        {
            return _chartDal.List1();
        }

        public List<ContentChartViewModel> GetList2()
        {
            return _chartDal.List2();
        }

        public List<HeadingChartViewModel> GetList3()
        {
            return _chartDal.List3();
        }
    }
}
