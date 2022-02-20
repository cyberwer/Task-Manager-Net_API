using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalDDS_Api.DataAccess.Repository
{
    public class EventLogRepository : GenericRepository<EventLog>, IEventLogRepository, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private bool disposed = false;
        public EventLogRepository(ApplicationDbContext DDDSContext)
            : base(DDDSContext)
        {
        }
        public List<EventLog> GetUserEventsLoglist(string userID)
        {
            return (from ev in unitOfWork.EventLogRepository.Get()
                    where ev.UserID == userID
                    select new EventLog
                    {
                        Created = ev.Created,                       
                        ActionMethod = ev.ActionMethod,
                        Value = ev.Value
                    }).OrderByDescending(d => d.Created).ToList();
        }
        public List<EventLog> GetEventsLogListForAdmin()
        {
            return (from ev in unitOfWork.EventLogRepository.Get()                  
                    select new EventLog
                    {
                        Created = ev.Created,
                        ActionMethod = ev.ActionMethod,
                        Value = ev.Value
                    }).OrderByDescending(d => d.Created).ToList();
        }
        public List<EventLog> GetTopTenEventsLogListForAdmin()
        {
            return (from ev in unitOfWork.EventLogRepository.Get()
                    select new EventLog
                    {
                        Created = ev.Created,
                        ActionMethod = ev.ActionMethod,
                        Value = ev.Value
                    }).Take(10).OrderByDescending(d => d.Created).ToList();
        }
        //public List<EventLog> GetEventsLogListForAdmin()
        //{
        //    return (from ev in unitOfWork.EventLogRepository.Get()
        //            select ev).Distinct().OrderByDescending(d => d.Created).ToList();

        //}


        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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