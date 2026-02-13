using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net10_WebApi.Data;
using Net10_WebApi.Models;
using Net10_WebApi.Models.DTO;

namespace Net10_WebApi.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Villas from the database. No parameters required.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villa>>> GetVillas()
        {
            return Ok(await _db.Villa.ToListAsync());
        }

        /// <summary>
        /// Retrieves the details of a villa by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the villa to retrieve. Must be a positive integer.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Villa>> GetVillaById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid villa ID. ID must be a positive integer.");
                }

                var villa = await _db.Villa.FirstOrDefaultAsync(x => x.Id == id);

                if (villa == null)
                {
                    return NotFound($"Villa with ID {id} not found.");
                }

                return Ok(villa);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving villa with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Villa>> CreateVilla(VillaCreateDTO villaDTO)
        {
            try
            {
                if (villaDTO == null)
                {
                    return BadRequest("Villa data is required.");
                }

                Villa villa = _mapper.Map<Villa>(villaDTO);
                villa.CreatedDate = DateTime.Now;

                await _db.Villa.AddAsync(villa);
                await _db.SaveChangesAsync();
                return Ok(villa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the villa: {ex.Message}");
            }
        }
    }
}
