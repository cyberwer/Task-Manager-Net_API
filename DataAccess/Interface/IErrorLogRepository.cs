using DentalDDS_Api.Models;
using System;
using System.Collections.Generic;

namespace DentalDDS_Api.DataAccess.Interface
{
    interface IErrorLogRepository : IGenericRepository<ErrorLog>, IDisposable
    {
        List<ErrorLog> GetAllErrorsLogListForAdmin();
        List<ErrorLog> GetTopTenErrorsLogListForAdmin();
        ErrorLog GetErrorsLogDetailForAdmin(long errID);
        List<ErrorLog> GetUserErrorsLogList(string userID);
    }
}
