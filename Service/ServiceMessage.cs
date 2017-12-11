using Data.Infrastructure;
using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceMessage : Service<message>, IServiceMessage
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork uwk = new UnitOfWork(dbf);
        public ServiceMessage(): base(uwk)
        {
        }
        public List<message> GetMessageByIdTopic(int id)
        {
            return uwk.GetRepository<message>().GetAll().Where(f => f.idTopic == id).ToList();

        }
    }
}
