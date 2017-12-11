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
    public class ServiceTopic : Service<topic>, IServiceTopic
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork uwk = new UnitOfWork(dbf);
        public ServiceTopic(): base(uwk)
        {
        }
    }
}
