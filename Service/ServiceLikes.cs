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
    public class ServiceLikes : Service<likes>, IServiceLikes
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork uwk = new UnitOfWork(dbf);
        public ServiceLikes(): base(uwk)
        {
        }
        public int GetFavorisBymsg(int id)
        {
            return uwk.GetRepository<likes>().GetAll().Where(f => f.idmessage == id).ToList().Count();

        }
        public virtual void Deletelike(likes l)
        {
            //   _repository.Delete(entity);
            uwk.GetRepository<likes>().Delete(uwk.GetRepository<likes>().GetMany(li => li.idmessage == l.idmessage && li.iduser == l.iduser).First());

        }
    }
}
