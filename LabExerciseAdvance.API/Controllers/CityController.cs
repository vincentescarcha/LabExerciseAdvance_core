using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabExerciseAdvance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        LabExerciseDBContext _context;
        readonly PersonRepository _repo;

        public CityController(LabExerciseDBContext context)
        {
            _context = context;
            _repo = new PersonRepository();
        }

        // GET: api/[controller]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var results = _context.Cities.ToList();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
    }
}