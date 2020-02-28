using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace EntityFrameworkAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MembersContext _context;

        public MembersController(MembersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Success retreiving data", Status = true, Data = _context.Members });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Members.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Member not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Members.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Member not found", Status = false });
            }

            _context.Members.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Member data)
        {
            _context.Members.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchMember(int id, [FromBody]JsonPatchDocument<Member> data)
        {
            data.ApplyTo(_context.Members.Find(id));
            _context.SaveChanges();
            return Ok();
        }

    }
}