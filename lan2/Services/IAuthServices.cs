using lan2.Data.ViewModels;
using lan2.Models;

namespace lan2.Services
{
    public interface IAuthServices
    {
        public AuthenticateResponseViewModel? Login(AuthenticateRequestViewModel model);
        public User? Register(RegisterRequestViewModel model);

    }
}
