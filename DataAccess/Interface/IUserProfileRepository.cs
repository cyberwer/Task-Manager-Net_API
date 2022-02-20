using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalDDS_Api.DataAccess.Interface
{
    interface IUserProfileRepository : IGenericRepository<UserProfile>, IDisposable
    {
        UserProfile GetUserID(string userName);
    }
}
