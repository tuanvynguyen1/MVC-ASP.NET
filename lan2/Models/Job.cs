using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lan2.Models
{
    public class Job
    {
        public enum job_status
        {
            Closed,
            Full,
            Opened
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }

        [Required]
        public job_status JobStatus { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

    }
}
