using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly DataContext _context;
        public WeaponRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public async Task Weapon(Weapon weapon)
        {
            await _context.Weapons.AddAsync(weapon);
            await _context.SaveChangesAsync();
        }

        //GET
        public async Task<Weapon> GetWeapon(int id)
        {
            var weapon = await _context.Weapons.SingleOrDefaultAsync(x => x.Id == id);

            return weapon;
        }

        public async Task<IEnumerable<Weapon>> GetAll()
        {
            var weapons = await _context.Weapons.ToListAsync();

            return weapons;
        }

        //PUT
        public async Task UpdateWeapon(Weapon weapon)
        {
            _context.Weapons.Update(weapon);
            await _context.SaveChangesAsync();   
        }

        //DELETE
        public async Task<string> DropPlan(int id)
        {
            _context.Remove(await _context.Weapons.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync());
            await _context.SaveChangesAsync();

            return "Usunięto broń";
    
        }
    }
}