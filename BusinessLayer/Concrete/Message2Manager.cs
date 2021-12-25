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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }




        public Message2 GetByID(int id)
        {
            return _message2Dal.Get(x => x.MessageId == id);
        }

        public List<Message2> GetInBoxListWriter(int id)
        {
            return _message2Dal.GetInBoxListWriter(id); //Writer mesajı alan of Message2 include
        }

        public List<Message2> GetSendBoxWriter(int id)
        {
            return _message2Dal.GetSendBoxWriter(id); //Writer mesajı gönderen of Message2 include
        }

        public List<Message2> GetTrashMessageWriter(int id)
        {
            return _message2Dal.GetTrashMessageWriter(id); //Trash
        }

        public List<Message2> GetList()
        {
            return _message2Dal.List().Where(x => x.MessageBool == true).ToList();
        }

        public void TAddBL(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void TDeleteBL(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public void TUpdateBL(Message2 t)
        {
            _message2Dal.Update(t);
        }


    }
}
