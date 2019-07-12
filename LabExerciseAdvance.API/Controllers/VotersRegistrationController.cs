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
    public class VotersRegistrationController : ControllerBase
    {
        readonly LabExerciseDBContext _context;
        readonly IRegistration<Adult> _registration;
        public VotersRegistrationController(LabExerciseDBContext context)
        {
            _context = context;
            _registration = new VotersRegistration<Adult>();
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