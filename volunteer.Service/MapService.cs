using Data.Infrastructure;
using Dev.Entities;
using Service.pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MapService : Service<mapaction>, IMapService
    {


        static DatabaseFactory Dbf = new DatabaseFactory();
        static UnitOfWork utw = new UnitOfWork(Dbf);

        public MapService() : base(utw)
        {
        }
    }
}
