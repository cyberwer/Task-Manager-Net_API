using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalDDS_Api.Models
{
    [Table("ErrorLog")]
    public partial class ErrorLog
    {
        public ErrorLog()
        {
            Created = DateTime.Now;
        }
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorID { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserID { get; set; }    
        
        [MaxLength(500)]
        public string ErrorMessage { get; set; } 
        
        [MaxLength(500)]
        public string ErrorStackTrace { get; set; }   
        
        [MaxLength(500)]
        public string ErrorInnerException { get; set; } 
        
        [MaxLength(50)]
        public string ActionMethod { get; set; }        

    }
}