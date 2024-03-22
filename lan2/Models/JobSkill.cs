using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lan2.Models
{
    public class JobSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public Job Job { get; init; }

        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; init; } 

        public byte YearOfExperience { get; set; } = 0;
    }
}
