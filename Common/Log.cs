using DentalDDS_Api.DataAccess;
using DentalDDS_Api.Models;
using System;
using System.Threading.Tasks;

namespace DentalDDS_Api.Common
{
    public class Log
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public Log()
        {
            
        }
        public async Task LogErrorAsync(string userID, string errorMessage, string errorSource, string innerException, string actionmethod)
        {
            if (!String.IsNullOrEmpty(userID) || !String.IsNullOrEmpty(actionmethod))
            {
                try
                {
                    var customError = new ErrorLog()
                    {
                        //UserID = userID,
                        //ErrorMessage = errorMessage,
                        //ErrorSource = errorSource,
                        //ErrorException = innerException,
                        //Event = actionmethod
                    };                  
                        _unitOfWork.ErrorLogRepository.Insert(customError);
                        await _unitOfWork.SaveAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                        return;               
                }
            }

        }
        public async Task LogEventAsync(string userID, string actionmethod, string value = "Sucessful")
        {
            if (!String.IsNullOrEmpty(userID) || !String.IsNullOrEmpty(actionmethod))
            {
                try
                {
                    var eventlog = new EventLog()
                    {
                        UserID = userID,
                        ActionMethod = actionmethod,
                        Value = value
                    };               
                    _unitOfWork.EventLogRepository.Insert(eventlog);
                    await _unitOfWork.SaveAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }
    }
}