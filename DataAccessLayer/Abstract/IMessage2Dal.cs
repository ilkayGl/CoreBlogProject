using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IRepository<Message2>
    {
        List<Message2> GetInBoxListWriter(int id); //Writer of message2 include
        List<Message2> GetSendBoxWriter(int id); //Writer of message2 include
        List<Message2> GetTrashMessageWriter(int id); //Trash writer
    }
}
