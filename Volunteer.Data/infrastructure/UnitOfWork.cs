

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RData.Infrastructure;
using Volunteer.Data;
using Volunteer.Data.Repositories;
using static Volunteer.Data.Repositories.DonationRepositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         public VolunteerContext dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }
        private IDonationRepositories DonationRepositorie;
    

        public DonationRepositories.IDonationRepositories DonationRepository
        {
            get
            {
                return DonationRepositorie = new DonationRepositories(dbFactory);
            }
        }


        public void Commit()
        {
            dataContext.SaveChanges();
        }
         public void CommitAsync()
         {
             dataContext.SaveChangesAsync();
         }
        public void Dispose()
        {
            dataContext.Dispose();
            dbFactory.Dispose();
        }
        public IRepositoryBaseAsync<T> getRepository<T>() where T : class
        {
            IRepositoryBaseAsync<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }


    }
}
