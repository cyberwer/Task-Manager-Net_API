using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using System;
using System.Threading.Tasks;

namespace DentalDDS_Api.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext DDDSContext = new ApplicationDbContext();

        public GenericRepository<UserProfile> userProfileRepository { get; private set; }
        public GenericRepository<Tasks> tasksRepository { get; private set; }      
        public GenericRepository<ErrorLog> errorLogRepository { get; private set; }      
        public GenericRepository<EventLog> eventLogRepository { get; private set; }
       


        ///Repository Context
        #region Repository Context

        public GenericRepository<UserProfile> UserProfileRepository
        {
            get
            {
                if (this.userProfileRepository == null)
                {
                    this.userProfileRepository = new GenericRepository<UserProfile>(DDDSContext);
                }
                return userProfileRepository;
            }
        }


        public GenericRepository<Tasks> TasksRepository
        {
            get
            {
                if (this.tasksRepository == null)
                {
                    this.tasksRepository = new GenericRepository<Tasks>(DDDSContext);
                }
                return tasksRepository;
            }
        }

      
        public GenericRepository<ErrorLog> ErrorLogRepository
        {
            get
            {
                if (this.errorLogRepository == null)
                {
                    this.errorLogRepository = new GenericRepository<ErrorLog>(DDDSContext);
                }
                return errorLogRepository;
            }
        }
      
        public GenericRepository<EventLog> EventLogRepository
        {
            get
            {
                if (this.eventLogRepository == null)
                {
                    this.eventLogRepository = new GenericRepository<EventLog>(DDDSContext);
                }
                return eventLogRepository;
            }
        }
      
        #endregion

        ///CRUD Methods
        #region Methods

        public async Task SaveAsync()
        {
            await DDDSContext.SaveChangesAsync(); 
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DDDSContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}