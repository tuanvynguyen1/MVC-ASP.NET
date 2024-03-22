using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lan2.Models
{
    public class Skill
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string SkillName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string SkillDescription { get; set;}
    }
}
