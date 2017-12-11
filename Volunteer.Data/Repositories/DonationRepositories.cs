using Data.Infrastructure;
using volunteer.domaine.entities;
using static Volunteer.Data.Repositories.DonationRepositories;

namespace Volunteer.Data.Repositories
{
    public class DonationRepositories : RepositoryBase<donation>, IDonationRepositories
    {
        public DonationRepositories(IDatabaseFactory dbFactory) : base(dbFactory)
        {   
        }
        public interface IDonationRepositories : IRepositoryBase<donation>
        {
        }
    }
}
