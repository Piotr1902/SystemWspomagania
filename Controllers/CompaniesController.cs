using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SystemWspomagania.API.Data;

namespace SystemWspomagania.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repo;
        private readonly DataContext _context;

        public CompaniesController(ICompanyRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetCompanies() 
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(companies);
        }
    }
}