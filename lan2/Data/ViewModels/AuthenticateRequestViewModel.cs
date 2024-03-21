using System.ComponentModel.DataAnnotations;

namespace lan2.Data.ViewModels
{
    public class AuthenticateRequestViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        
        
    }
}
