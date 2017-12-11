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
   public class ServiceFavoris : Service<favoris>, IServiceFavoris
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork uwk = new UnitOfWork(dbf);
        public ServiceFavoris(): base(uwk)
        {
        }
        public List<favoris> GetFavorisByUser(int id)
        {
            return uwk.GetRepository<favoris>().GetAll().Where(f => f.iduser == id).ToList();

        }
        public virtual void Deletefavoris(favoris f)
        {
            //   _repository.Delete(entity);
            uwk.GetRepository<favoris>().Delete(uwk.GetRepository<favoris>().GetMany(fa => fa.idtopic == f.idtopic && fa.iduser==f.iduser).First());

        }
    }
}
