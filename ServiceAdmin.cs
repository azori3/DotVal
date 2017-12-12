using DATA.Infrastructure;
using pidevDomain;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ServiceAdmin : Service<Admin>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ServiceAdmin() : base(utwk)
        {
        }
    }
}
