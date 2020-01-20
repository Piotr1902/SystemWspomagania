using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class IssueWeaponRepository : IIssueWeaponRepository
    {
        private readonly DataContext _context;
        public IssueWeaponRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public async Task IssueWeapon(IssueWeapon issueWeapon)
        {
            await _context.IssueWeapons.AddAsync(issueWeapon);
            await _context.SaveChangesAsync();
        }

        //GET
        public async Task<IssueWeapon> GetIssueWeapon(int id)
        {
            var issueWeapon = await _context.IssueWeapons.SingleOrDefaultAsync(x => x.Id == id);

            return issueWeapon;
        }

        public async Task<IEnumerable<IssueWeapon>> GetAll()
        {
            var issueWeapons = await _context.IssueWeapons.ToListAsync();

            return issueWeapons;
        }

        //PUT
        public async Task UpdateIssueWeapon(IssueWeapon issueWeapon)
        {
            _context.IssueWeapons.Update(issueWeapon);
            await _context.SaveChangesAsync();
        }
    }
}