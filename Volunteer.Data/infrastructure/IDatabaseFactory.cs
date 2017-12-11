

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Data;

namespace Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        VolunteerContext DataContext { get; }
    }

}
