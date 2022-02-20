using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;

namespace DentalDDS_Api.DataAccess.Interface
{
    interface IEventLogRepository : IGenericRepository<EventLog>, IDisposable
    {      
        List<EventLog> GetUserEventsLoglist(string userID);
        List<EventLog> GetEventsLogListForAdmin();
        List<EventLog> GetTopTenEventsLogListForAdmin();
    }
}
