using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.Models;
using System;
using System.Linq;

namespace DentalDDS_Api.DataAccess.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private bool disposed = false;
        public UserProfileRepository(DbContext.ApplicationDbContext dentalDDSContext)
            : base(dentalDDSContext)
        {
        }

        public UserProfile GetUserID(string userName)
        {
            return (from ur in unitOfWork.UserProfileRepository.Get()
                    where ur.UserName == userName
                    select new UserProfile
                    {
                        UserProfileID = ur.UserProfileID

                    }).FirstOrDefault();
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