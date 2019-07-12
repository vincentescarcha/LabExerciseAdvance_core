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
        readonly PersonRepository _repo;
        readonly IRegistration<Adult> _registration;
        public VotersRegistrationController()
        {
            _repo = new PersonRepository();
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

        // POST: api/[controller]/{id}
        [HttpPost("{id:int}")]
        public ActionResult Post(int id)
        {
            try
            {
                Person person = _repo.GetSpecific(id);
                if (person == null)
                {
                    throw new Exception("No Record Found");
                }

                if (!person.TryParseTo(typeof(Adult), out Adult convertedPerson))
                {
                    throw new Exception("Person is not " + typeof(Adult).Name);
                }
                _registration.RegisterPerson(convertedPerson);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}