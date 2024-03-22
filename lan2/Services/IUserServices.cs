using lan2.Models;

namespace lan2.Services
{
    public interface IUserServices
    {
        public User? GetUserByID(int id);
    }
}
