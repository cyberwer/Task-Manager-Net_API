using DentalDDS_Api.Models;
using System;
using System.Threading.Tasks;

namespace DentalDDS_Api.DataAccess.Interface
{

    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<UserProfile> UserProfileRepository { get; }
        GenericRepository<Tasks> TasksRepository { get; }
        GenericRepository<ErrorLog> ErrorLogRepository { get; }
        GenericRepository<EventLog> EventLogRepository { get; }
                 
        Task SaveAsync();
    }
}
