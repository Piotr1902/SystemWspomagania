using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemWspomagania.API.Data;
using SystemWspomagania.API.Dtos;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class IssueWeaponController : ControllerBase
    {
        private readonly IIssueWeaponRepository _repo;
        private readonly DataContext _context;

        public IssueWeaponController(IIssueWeaponRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpPost("issueWeapons")]
        public async Task<IActionResult> issueWeapons(IssueWeaponWeaponDto issueWeaponWeaponDto)
        {
            var issueWeaponToCreate = new IssueWeapon
            {
                Id = issueWeaponWeaponDto.Id,
                DateIssue = issueWeaponWeaponDto.DateIssue,
                DateReturn = issueWeaponWeaponDto.DateReturn,
                WeaponId = issueWeaponWeaponDto.WeaponId
            };

            await _repo.IssueWeapon(issueWeaponToCreate);

            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssueWeapon(int id, IssueWeaponWeaponDto issueWeaponWeapon)
        {
            var IssueWeapon = await _repo.GetIssueWeapon(id);
            
            IssueWeapon.DateIssue = issueWeaponWeapon.DateIssue;
            IssueWeapon.DateReturn = issueWeaponWeapon.DateReturn;
            IssueWeapon.Stan = issueWeaponWeapon.Stan;

           await _repo.UpdateIssueWeapon(IssueWeapon);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueWeapon(int id)
        {
            var issueWeapon = await _repo.GetIssueWeapon(id);

            return Ok(issueWeapon);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var issueWeapons = await _repo.GetAll();
            

            return Ok(issueWeapons);
        }
        
    }
}