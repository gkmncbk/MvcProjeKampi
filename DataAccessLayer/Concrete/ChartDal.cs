using DataAccessLayer.Abstract;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ChartDal : IChartDal
    {
        Context c = new Context();



        public List<CategoryChartViewModel> List1()
        {
            List<CategoryChartViewModel> ct = new List<CategoryChartViewModel>();

            List<ContentChartViewModel> cc = (from p in c.Contents.GroupBy(x => x.Heading.HeadingName)

                                              select new ContentChartViewModel
                                              {

                                                  HeadingName = p.Key,
                                                  ContentCount = p.Count(),


                                              }).ToList();



            ct.Add(new CategoryChartViewModel()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryChartViewModel()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryChartViewModel()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryChartViewModel()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }

        public List<ContentChartViewModel> List2()
        {
            List<ContentChartViewModel> ct = (from p in c.Contents.GroupBy(x => x.Heading.HeadingName)

                                              select new ContentChartViewModel
                                              {

                                                  HeadingName = p.Key,
                                                  ContentCount = p.Count(),


                                              }).ToList();


            return ct;
        }

        public List<HeadingChartViewModel> List3()
        {
            List<HeadingChartViewModel> ct = (from p in c.Headings.GroupBy(x => x.Category.CategoryName)

                                              select new HeadingChartViewModel
                                              {

                                                  CategoryName = p.Key,
                                                  HeadingCount = p.Count(),


                                              }).ToList();


            return ct;
        }
    }
}
