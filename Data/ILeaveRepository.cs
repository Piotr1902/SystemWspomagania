using System.Collections.Generic;
using System.Threading.Tasks;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public interface ILeaveRepository
    {
        //POST
         Task Leave(Leave leave);
         //PUT
         Task UpdateLeave(Leave leave);
         //GET
         Task<Leave> GetLeave(int id);
         Task<IEnumerable<Leave>> GetAll();
    }
}