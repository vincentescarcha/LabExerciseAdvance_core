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
        readonly PersonRepository _repo;
        readonly IRegistration<Infant> _registration;
        public DayCareRegistrationController()
        {
            _repo = new PersonRepository();
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

                if (!person.TryParseTo(typeof(Infant), out Infant convertedPerson))
                {
                    throw new Exception("Person is not " + typeof(Infant).Name);
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