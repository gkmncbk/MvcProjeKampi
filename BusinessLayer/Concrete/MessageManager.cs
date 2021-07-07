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
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p, string k)
        {
            return _messageDal.List(x => x.ReceiverMail == p && (x.MessageContent.Contains(k)||x.Subject.Contains(k)||x.SenderMail.Contains(k)));

            //return _messageDal.List();
        }
        public List<Message> GetListSendbox(string p, string k)
        {
            return _messageDal.List(x => x.SenderMail ==p && x.MessageDraftsStatus==false && (x.MessageContent.Contains(k) || x.Subject.Contains(k) || x.ReceiverMail.Contains(k)));

        }
        public List<Message> GetListDraftbox(string p, string k)
        {
            return _messageDal.List(x => x.SenderMail == p && x.MessageDraftsStatus == true && (x.MessageContent.Contains(k) || x.Subject.Contains(k) || x.ReceiverMail.Contains(k)));

        }
        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
