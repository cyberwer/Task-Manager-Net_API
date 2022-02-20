using System;
using System.ComponentModel.DataAnnotations;

namespace DentalDDS_Api.BindingModels
{
    public class BindingModel
    {
    }

    public class TasksBM
    {
        public long TasksID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }
        [Required]
        [MaxLength(200)]
        public string TaskDetail { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        public DateTime TaskDateTime { get; set; }
    }
    public class UpdateTasksBM
    {
        [Required]
        public long TasksID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }
        [Required]
        [MaxLength(200)]
        public string TaskDetail { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        public DateTime TaskDateTime { get; set; }
    }

    public class userRegister
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }


    }
}
