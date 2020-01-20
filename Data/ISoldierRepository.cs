using System.Collections.Generic;
using System.Threading.Tasks;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public interface ISoldierRepository
    {
        Task<IEnumerable<Soldier>> GetSoldiers();
         
    }
}