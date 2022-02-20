
using DentalDDS_Api.DataAccess.Interface;
using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalDDS_Api.DataAccess.Repository
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private bool disposed = false;
        public TasksRepository(DbContext.ApplicationDbContext dentalDDSContext)
            : base(dentalDDSContext)
        {
        }
        public List<Tasks> GetTasksListByUserName(string userName)
        {
            return (from tx in unitOfWork.TasksRepository.Get()
                    where tx.UserName == userName
                    select new Tasks
                    {
                        TasksID = tx.TasksID,
                        TaskName = tx.TaskName,
                        TaskDetail = tx.TaskDetail,
                        TaskDateTime = tx.TaskDateTime,
                        Created = tx.Created

                    }).OrderBy(s => s.TaskDateTime).ToList();
        }

        public Tasks GetSelectedTaskByTaskID(long taskID)
        {
            return (from tx in unitOfWork.TasksRepository.Get()
                    where tx.TasksID == taskID
                    select new Tasks
                    {
                        TasksID = tx.TasksID,
                        TaskName = tx.TaskName,
                        TaskDetail = tx.TaskDetail,
                        TaskDateTime = tx.TaskDateTime,
                        Created = tx.Created

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