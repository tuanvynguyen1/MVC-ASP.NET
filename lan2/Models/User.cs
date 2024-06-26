﻿using lan2.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lan2.Models
{
    public class User
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "First Name must contain at least 5 character and maximum to 50 character")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Last Name must contain at least 5 character and maximum to 50 character")]
        public string LastName { get; set; }
        
        [ValidateEmail(ErrorMessage ="Email format is not support!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email length must between 5 and 70 character")]
        public string Email { get; set; }
        [JsonIgnore]
        [Required]
        [StringLength(100, MinimumLength =8, ErrorMessage ="Password must contain atleast 8 character")]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength =8, ErrorMessage ="Username must contain atleast 8 character and maximum to 50 character")]
        public string UserName { get; set; }
        [ValidatePhone(ErrorMessage ="Phone format is not support!")]
        [StringLength(11, MinimumLength = 9)]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "text")]
        public string? Avatar {  get; set; }

        public ICollection<UserSkill> userSkills { get; } = new List<UserSkill>(); 

    }
}
