using DentalDDS_Api.Common.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Claims;
using System.Linq;

namespace DentalDDS_Api.Common
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserId()
        {
            return _context.HttpContext.User.Claims
                       .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}