using System.Collections.Generic;
using System.Threading.Tasks;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public interface IIssueWeaponRepository
    {
         //POST
         Task IssueWeapon(IssueWeapon issueWeapon);
         //PUT
         Task UpdateIssueWeapon(IssueWeapon issueWeapon);
         //Get
         Task<IssueWeapon> GetIssueWeapon(int id);
         Task<IEnumerable<IssueWeapon>> GetAll();
    }
}