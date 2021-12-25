using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInBoxListWriter(int id)
        {
            using var c = new Context();
            return c.Message2s.Include(x => x.SenderUser).Where(y => y.ReceiverId == id).Where(y => y.MessageBool == true && y.SenderUser.WriterStatus == true).OrderByDescending(d => d.MessageDate).ToList(); //Writer of message2 include
        }

        public List<Message2> GetSendBoxWriter(int id)
        {
            using var c = new Context();
            return c.Message2s.Include(x => x.ReceiverUser).Where(y => y.SenderId == id).Where(y => y.MessageBool == true && y.ReceiverUser.WriterStatus == true).OrderByDescending(d => d.MessageDate).ToList();
        }

        public List<Message2> GetTrashMessageWriter(int id)
        {
            using var c = new Context();
            return c.Message2s.Include(x => x.ReceiverUser).Where(m => m.MessageBool == false).Include(x => x.SenderUser).Where(y => y.MessageBool == false).OrderByDescending(d => d.MessageDate).ToList();
        }
    }
}
