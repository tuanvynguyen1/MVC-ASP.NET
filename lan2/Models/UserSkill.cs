
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace lan2.Models
{
    public class UserSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; init; }
        [JsonIgnore]
        public User User { get; init; }
        public byte YearOfExperience { get; set; } = 0;
    }
}
