using System.ComponentModel.DataAnnotations;

namespace lan2.Data.ViewModels
{
    public class AuthenticateResponseViewModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname
        { get; set; }
        [Required]
        public string refreshToken { get; set; }
        [Required]
        public string token { get; set; }

        public AuthenticateResponseViewModel(string username, string email, string firstname, string lastname, string refreshToken, string token)
        {
            this.username = username;
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.refreshToken = refreshToken;
            this.token = token;
        }
    }
}
