using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "Editor")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly FINALContext _context;

        public EditorController(FINALContext context)
        {
            _context = context;
        }
    }
}
