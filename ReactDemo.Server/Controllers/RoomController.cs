using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Server.Database;
using ReactDemo.Server.Models;
using System.Threading.Tasks;

namespace ReactDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context) { 
            _context = context;
        }

        [HttpGet()]
        public async Task<List<RoomType>> Get()
        {
            return (List<RoomType>)await _context.RoomType.ToListAsync();
        }
    }
}
