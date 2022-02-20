using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalDDS_Api.Models
{

    [Table("EventLog")]
    public partial class EventLog
    {
        public EventLog()
        {
            Created = DateTime.Now;
        }
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserID { get; set; }
        public string ActionMethod { get; set; }
        public string Value { get; set; }
        [Required]
        public DateTime Created { get; set; }


    }
}