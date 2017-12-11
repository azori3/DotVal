using RData.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Volunteer.Data.Repositories.DonationRepositories;

namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        

        IRepositoryBaseAsync<T> getRepository<T>() where T : class;
        IDonationRepositories DonationRepository { get; }
        void CommitAsync();
        void Commit();
       
    }

}
