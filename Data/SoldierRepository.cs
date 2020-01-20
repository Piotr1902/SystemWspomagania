using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class SoldierRepository : ISoldierRepository
    {
        private readonly DataContext _context;

        public SoldierRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Soldier>> GetSoldiers()
        {
            var soldiers = await _context.Soldiers.ToListAsync();
            return soldiers;
        }

    }
}