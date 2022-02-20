using DentalDDS_Api.BindingModels;
using DentalDDS_Api.Common;
using DentalDDS_Api.DataAccess;
using DentalDDS_Api.DbContext;
using DentalDDS_Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

//Resouces
//https://bitoftech.net/2015/01/21/asp-net-identity-2-with-asp-net-web-api-2-accounts-management/

namespace DentalDDS_Api.Controllers
{

    [RoutePrefix("api/account")]
    public class AccountController : BaseApiController
    {
       
        private const string LocalLoginProvider = "Local";
        private ApplicationUser _businessUser;
        private Log _lg = null;
       
        private UnitOfWork _uw = new UnitOfWork();
        private RolesManagement _rm = null;


        public AccountController()
        {           
            _rm = new RolesManagement();
            _lg = new Log();
           
        }
        public AccountController(ISecureDataFormat<AuthenticationTicket> accessTokenFormat, Log log)
        {
            //UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        [AllowAnonymous]
        [HttpGet]
        [Route("APITest")]
        public IHttpActionResult APITest()
        {
            return Content(HttpStatusCode.OK, "Dental DDS API!.");
        }


        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// POST api/account/ApiLogout
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        [Route("ApiLogout")]
        public IHttpActionResult ApiLogout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }       

        /// <summary>      
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUserByName/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                return Content(HttpStatusCode.NotFound, "Missing userID.");
            }
            var user = await this.AppUserManager.FindByNameAsync(userName);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        /// <summary>        
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetUserRoleByID/{userID}")]
        public async Task<IHttpActionResult> GetUserRoleByID(string userID)
        {
            if (String.IsNullOrEmpty(userID))
            {
                return Content(HttpStatusCode.NotFound, "Missing userID.");
            }
            var userRole = await this.AppUserManager.GetRolesAsync(userID);
            if (userRole != null)
            {
                return Ok(userRole);
            }
            return Content(HttpStatusCode.NotFound, "No role found");
        }

      

        /// <summary>       
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("AssignRolesToUser/{id:guid}/roles")]
        [HttpGet]
        public IHttpActionResult GetAllRoles()
        {
            var roles = this.AppRoleManager.Roles;

            return Ok(roles);
        }
        /// <summary>      
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [Route("AssignRolesToUser/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> CreateRole(CreateRoleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var role = new IdentityRole { Name = model.Name };
            var result = await this.AppRoleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return NotFound();
            }
            Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));
            //return Created(locationHeader, TheModelFactory.Create(role));
            return Content(HttpStatusCode.OK, locationHeader);

        }

        /// <summary>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("AssignRolesToUser/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> DeleteRole(string Id)
        {
            var role = await this.AppRoleManager.FindByIdAsync(Id);
            if (role != null)
            {
                IdentityResult result = await this.AppRoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Content(HttpStatusCode.OK, "Role deleted");
                }
            }
            return Content(HttpStatusCode.NotFound, "No role found");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PostUserRegister")]
        public async Task<IHttpActionResult> PostUserRegister(userRegister model)
        {
            if (!ModelState.IsValid)
            {
                return Content(System.Net.HttpStatusCode.NotFound, model);
            }

            var loginUserId = model.Email.ToLower();
            var _user = new ApplicationUser()
            {
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                PhoneNumber = model.MobileNumber,
                JoinDate = DateTime.Now.Date,
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                UserProfile = new UserProfile()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MobilNumber = model.MobileNumber,
                    UserName = model.Email.ToLower(),                    
                    Created = DateTime.Now
                },
            };
            using (ApplicationDbContext registerDbContext = new ApplicationDbContext())
            {
                using (var dbTran = registerDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var result = await AppUserManager.CreateAsync(_user, model.Password);
                        if (result.Succeeded)
                        {
                            string code = await AppUserManager.GenerateEmailConfirmationTokenAsync(_user.Id);
                            var callbackUrl = new Uri(Url.Link("ConfirmEmail", new { userId = _user.Id, code = code }));
                            var x = registerDbContext.SaveChanges();
                            //commit transaction
                            dbTran.Commit();
                            await _lg.LogEventAsync(_user.Id, "Post Register");
                            return Content(HttpStatusCode.Created, "Register Successful");
                        }
                        else
                        {
                            return Content(HttpStatusCode.BadRequest, result);
                        }

                    }
                    catch (Exception ex)
                    {
                        //await _lg.LogErrorAsync(_businessUser.Id, ex.Message, ex.Source, ex.InnerException.ToString(), "PostProviderRegister");
                        return Content(System.Net.HttpStatusCode.NotFound, ex.Message);
                    }

                }
            }

        }

        #region Helpers
      
        [AllowAnonymous]
        [Route("ConfirmEmail", Name = "ConfirmEmail")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest();
            }

            IdentityResult result = await AppUserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {

                await _lg.LogEventAsync(userId, "ConfirmEmail");
                //send wellcome email
                return Ok();

            }
            else
            {
                return GetErrorResult(result);
            }

        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }


        #endregion

     
    }
}
