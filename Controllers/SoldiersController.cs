using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Data;

namespace SystemWspomagania.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SoldiersController : ControllerBase
    {
        private readonly ISoldierRepository _repo;
        private readonly DataContext _context;
        public SoldiersController(ISoldierRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("soldiers")]
        public async Task<IActionResult> GetSoldiers()
        {
            var soldiers = await _context.Soldiers.ToListAsync();
            return Ok(soldiers);
        }


    }
}