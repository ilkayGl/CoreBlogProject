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
            return c.Message2s.Include(x => x.SenderUser).Where(y => y.ReceiverId == id).Where(y => y.MessageBool == true && y.SenderUser.WriterStatus == true).OrderByDescending(d => d.MessageDate).Take(3).ToList(); //Writer of message2 include
        }
    }
}
