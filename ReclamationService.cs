
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Infrastructure;
using pidevDomain;

namespace Services
{
    public class ReclamationService : Service<Report>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ReclamationService() : base(utwk)
        {
        }
        public IEnumerable<user> getAllreports()
        {
            return utwk.getRepository<user>().GetAll();
        }
    }
}
