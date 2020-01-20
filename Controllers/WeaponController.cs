using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Data;
using SystemWspomagania.API.Dtos;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponRepository _repo;
        private readonly DataContext _context;
        public WeaponController(IWeaponRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpPost("weapons")]
        public async Task<IActionResult> Weapon(WeaponDto weaponDto)
        {
            var weaponToCreate = new Weapon
            {
                Id = weaponDto.Id,
                Name = weaponDto.Name,
                Seria = weaponDto.Seria,
                SoldierId = weaponDto.SoldierId
            };

            await _repo.Weapon(weaponToCreate);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeapon(int id, WeaponUpdateDto weaponUpdateDto)
        {
            var weapon = await _repo.GetWeapon(id);

            weapon.SoldierId = weaponUpdateDto.SoldierId;
            
            await _repo.UpdateWeapon(weapon);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeapon(int id){

            var weapon = await _repo.GetWeapon(id);

            return Ok(weapon);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            var weapons = await _repo.GetAll();
            var merged = weapons.Select(x => Map(x));

            return Ok(merged);
        }

        private WeaponSoldierDto Map(Weapon weapon)
        {
            var soldier =  _context.Soldiers.SingleOrDefault(x => x.Id == weapon.SoldierId);
            var weaponSoldierDto = new WeaponSoldierDto
            {
                SoldierName = $"{soldier.Name} {soldier.Surname}",
                Name = weapon.Name,
                Seria = weapon.Seria,
                Id = weapon.Id,
                SoldierId = soldier.Id
            };

            return weaponSoldierDto;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DropPlan(int id)
        {
            return Ok(await _repo.DropPlan((int)id));
        }
        
    }
}