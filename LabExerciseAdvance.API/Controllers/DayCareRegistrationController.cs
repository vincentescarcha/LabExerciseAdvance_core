using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabExerciseAdvance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayCareRegistrationController : ControllerBase
    {
        readonly LabExerciseDBContext _context;
        readonly IRegistration<Infant> _registration;
        public DayCareRegistrationController(LabExerciseDBContext context)
        {
            _context = context;
            _registration = new DayCareRegistration<Infant>();
        }
        // GET: api/[controller]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var results = _registration.GetRegisteredPersons().ToPersonView().ToList();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}