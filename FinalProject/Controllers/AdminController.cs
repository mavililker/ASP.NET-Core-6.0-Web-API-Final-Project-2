using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly FINALContext _context;

        public AdminController(FINALContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTrades()
        {
            try
            {
                return Ok(_context.Trades);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error.");
            }

        }

    }
}
