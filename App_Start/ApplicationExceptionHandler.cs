using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace DentalDDS_Api.App_Start
{
    public class ApplicationExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // used for when user is not authorized to access a WebAPI controller method
            if (context.Exception is UnauthorizedAccessException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            // used for "item with same XY (for example "name") already exists"
            else if (context.Exception is ArgumentException)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(context.Exception.Message)
                };

                throw new HttpResponseException(response);
            }
            // used for exceptions that do not make sense from the business logic point of view
            else if (context.Exception is InvalidOperationException)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(context.Exception.Message)
                };

                throw new HttpResponseException(response);
            }
        }
    }
}