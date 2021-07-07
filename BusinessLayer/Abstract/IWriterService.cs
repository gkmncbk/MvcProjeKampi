﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        Writer GetByID(int id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        //Writer GetByWriter(string mail, string password);
        int GetByWriterId(string mail);

    }
}
