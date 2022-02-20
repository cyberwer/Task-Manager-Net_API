using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalDDS_Api.Models
{  

    [Table("UserProfile")]
    public class UserProfile
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long UserProfileID { get; set; }

        [Key, ForeignKey("ApplicationUser")]
        public string UserProfileID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string MobilNumber { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime Created { get; set; }


        //Relatioship
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}