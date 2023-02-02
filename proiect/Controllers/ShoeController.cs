using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Data;
using proiect.Models.DTOs.ShoeDTO;
using proiect.Services.ShoeService;

namespace proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeService _shoeService;
        private readonly DataBaseContext _context;

        public ShoeController(IShoeService shoeService, DataBaseContext context)
        {
            _shoeService = shoeService;
            _context = context;
        }


        [HttpPost]
        public async Task<ShoeDTO> AddShoe(ShoeDTO shoe)
        {
            return await _shoeService.AddShoe(shoe);
        }

        [HttpPut("{id}")]
        public async Task<ShoeDTO> UpdateShoe(ShoeDTO shoe, bool availability)
        {
            return await _shoeService.UpdateShoe(shoe,availability);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShpe(Guid id)
        {
            var shoe = await _shoeService.GetShoe(id);
            if (shoe == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.User;

            if (!currentUser.Identity.IsAuthenticated) return Forbid();

            if (currentUser.IsInRole("Admin"))
            {
                await _shoeService.DeleteShoe(id);
                return NoContent();
            }
            else
            {
                return Forbid();
            }
        }
    }
}
