using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;

namespace DentalDDS_Api.DataAccess.Interface
{
    interface ITasksRepository : IGenericRepository<Tasks>, IDisposable
    {
        List<Tasks> GetTasksListByUserName(string userName);
        Tasks GetSelectedTaskByTaskID(long taskID);
    }
}
