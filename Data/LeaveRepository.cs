using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly DataContext _context;
        public LeaveRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public async Task Leave(Leave leave)
        {
            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();
        }

        //GET
        public async Task<Leave> GetLeave(int id)
        {
            var leave = await _context.Leaves.SingleOrDefaultAsync(x => x.Id == id);

            return leave;
        }


        public async Task<IEnumerable<Leave>> GetAll()
        {
            var leaves = await _context.Leaves.ToListAsync();

            return leaves;
        }
        
        //PUT
        public async Task UpdateLeave(Leave leave)
        {
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
        }
    }
}