using DentalDDS_Api.DataAccess;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace DentalDDS_Api.Common
{
    public class RolesManagement
    {
        private UnitOfWork uw = new UnitOfWork();
        private Log _lg = new Log();
        ApplicationDbContext context = new ApplicationDbContext();
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public RolesManagement()
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
   
        public async Task SetUserRoleAsync(string userID, string rolename)
        {

            string userName = userID;
            string roleName = rolename;

            if (!String.IsNullOrEmpty(userName) || !String.IsNullOrEmpty(roleName))
            {
                try
                {
                    _userManager.AddToRole(userName, roleName);
                }
                catch (Exception ex)
                {
                    await _lg.LogErrorAsync(userName, ex.Message, ex.Source, ex.InnerException.ToString(), "SetUserRoleAsync").ConfigureAwait(false);
                    return;
                }

            }
        }

        public async Task SetUserRole(string userID, string roleName)
        {

            //var userManager = new HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (!String.IsNullOrEmpty(userID) || !String.IsNullOrEmpty(roleName))
            {
                try
                {
                    _userManager.AddToRole(userID, roleName);
                    await _lg.LogEventAsync(userID, "RegisterProcess").ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    await _lg.LogErrorAsync(userID, ex.Message, ex.Source, ex.InnerException.ToString(), "SetUserRoleAsync").ConfigureAwait(false);

                }
            }
        }

    }
}
