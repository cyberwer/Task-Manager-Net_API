using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalDDS_Api.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TasksID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }
        [Required]
        [MaxLength(200)]
        public string TaskDetail { get; set; }
        [Required]
        public DateTime TaskDateTime { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        public string UserProfileID { get; set; }

    }
}