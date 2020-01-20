using System.Collections.Generic;
using System.Threading.Tasks;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public interface IWeaponRepository
    {
        //POST
        Task Weapon(Weapon weapon);
        //PUT
        Task UpdateWeapon(Weapon weapon);
        //GET
        Task<Weapon> GetWeapon(int id);
        Task<IEnumerable<Weapon>> GetAll();
        //DELETE
        Task<string> DropPlan(int id);
    }
}