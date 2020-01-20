using System.Threading.Tasks;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public interface IAuthRepository
    {
         Task<Soldier> Register(Soldier soldier, string password);
         Task<Soldier> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}