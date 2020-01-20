using System.Collections.Generic;
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
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _repo;
        private readonly DataContext _context;

        public LeaveController(ILeaveRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }
        
        [HttpPost("leaves")]
        public async Task<IActionResult> leaves(LeaveSoldierDto leaveSoldierDto)
        {
            var leaveToCreate = new Leave
            {
                Id = leaveSoldierDto.Id,
                DateLeave = leaveSoldierDto.DateLeave,
                DateReturn = leaveSoldierDto.DateReturn,
                SoldierId = leaveSoldierDto.SoldierId,
                Where = leaveSoldierDto.Where,
                Typ = leaveSoldierDto.Typ,
                Annotation = leaveSoldierDto.Annotation
            };

            await _repo.Leave(leaveToCreate);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeave(int id, LeaveSoldierUpdateDto leaveSoldierUpdateDto)
        {
            var leave = await _repo.GetLeave(id);
            
            leave.DateReturn = leaveSoldierUpdateDto.DateReturn;
            leave.Annotation = leaveSoldierUpdateDto.Annotation;

           await _repo.UpdateLeave(leave);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeave(int id)
        {
            var leave = await _repo.GetLeave(id);
            
            return Ok(leave);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var leaves = await _repo.GetAll();
            var merged = leaves.Select(x =>Map(x));

            return Ok(merged);
        }

        private LeaveSoldierDto Map(Leave leave)
        {
            var soldier = _context.Soldiers.SingleOrDefault(x => x.Id == leave.SoldierId);
            var leaveSoldierDto = new LeaveSoldierDto
            {
                SoldierName = $"{soldier.Name} {soldier.Surname}",
                DateLeave = leave.DateLeave,
                DateReturn = leave.DateReturn,
                Where = leave.Where,
                Typ = leave.Typ,
                Annotation = leave.Annotation,
                Id = leave.Id
            };

            return leaveSoldierDto;
        }

    }
}