using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CapabilityManager : ICapabilityService
    {
        ICapabilityDal _capabilityDal;

        public CapabilityManager(ICapabilityDal capabilityDal)
        {
            _capabilityDal = capabilityDal;
        }

        public void CapabilityAdd(Capability capability)
        {
            _capabilityDal.Insert(capability);
        }

        public void CapabilityDelete(Capability capability)
        {
            _capabilityDal.Delete(capability);
        }

        public void CapabilityUpdate(Capability capability)
        {
            _capabilityDal.Update(capability);
        }

        public Capability GetByID(int id)
        {
            return _capabilityDal.Get(x => x.CapabilityID == id);
        }

        public List<Capability> GetList()
        {
            return _capabilityDal.List();
        }
    }
}
