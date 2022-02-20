using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentalDDS_Api.Models
{
  
    public enum Domain
    {
        
    }

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public Domain Domain { get; set; }


        ///One-One Relationship with UserAccount entity Relationship might come in handy later?
        #region Relationship
       
        public virtual UserProfile UserProfile { get; set; }  // users relationship   

        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
}