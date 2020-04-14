using System.Threading.Tasks;

namespace PortalRandkowy.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(string username, string password);
        Task<bool> UserExist(string username);
        
    }
}