using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net10_WebApi.Data;
using Net10_WebApi.Models;

namespace Net10_WebApi.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaController: ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villa>>> GetVillas()
        {
            return Ok(await _db.Villa.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public string GetVillaById(int id)
        {
            return $"Get VillaID: {id}";
        }
    }
}
