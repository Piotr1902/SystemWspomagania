using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Company>> getCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }
    }
}