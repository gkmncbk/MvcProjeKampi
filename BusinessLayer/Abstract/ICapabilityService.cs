using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICapabilityService
    {
        List<Capability> GetList();
        void CapabilityAdd(Capability capability);
        Capability GetByID(int id);
        void CapabilityDelete(Capability capability);
        void CapabilityUpdate(Capability capability);
    }
}
