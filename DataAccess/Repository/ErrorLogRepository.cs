using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalDDS_Api.DataAccess.Repository
{
    public class ErrorLogRepository : GenericRepository<ErrorLog>, IErrorLogRepository, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private bool disposed = false;
        public ErrorLogRepository(ApplicationDbContext DDDSContext) : base(DDDSContext)
        {
            return;
        }
        public List<ErrorLog> GetAllErrorsLogListForAdmin()
        {
            return (from er in unitOfWork.ErrorLogRepository.Get()                    
                    select new ErrorLog
                    {
                        Created = er.Created,
                       
                        ActionMethod = er.ActionMethod,
                        ErrorID = er.ErrorID                                           

                    }).OrderByDescending(er => er.Created).ToList();
        }
        public List<ErrorLog> GetTopTenErrorsLogListForAdmin()
        {
            return (from er in unitOfWork.ErrorLogRepository.Get()
                    select new ErrorLog
                    {
                        Created = er.Created,                       
                        ActionMethod = er.ActionMethod,
                        ErrorID = er.ErrorID                        

                    }).Take(10).OrderByDescending(er => er.Created).ToList();
        }
        public ErrorLog GetErrorsLogDetailForAdmin(long errID)
        {
            return (from er in unitOfWork.ErrorLogRepository.Get()
                    where er.ErrorID == errID
                    select new ErrorLog
                    {
                        Created = er.Created,
                        UserID = er.UserID,
                        ActionMethod = er.ActionMethod,
                        ErrorID = er.ErrorID,
                        ErrorInnerException = er.ErrorInnerException,
                        ErrorMessage = er.ErrorMessage,
                        ErrorStackTrace = er.ErrorStackTrace

                    }).SingleOrDefault();
        }
        public List<ErrorLog> GetUserErrorsLogList(string userID)
        {
            return (from er in unitOfWork.ErrorLogRepository.Get()
                    where er.UserID == userID
                    select new ErrorLog
                    {
                        Created = er.Created,                       
                        ActionMethod = er.ActionMethod,
                        ErrorID = er.ErrorID                       

                    }).OrderByDescending(er => er.Created).ToList();
        }



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