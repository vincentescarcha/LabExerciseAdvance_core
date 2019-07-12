using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
//using AutoMapper.Configuration;
using LabExerciseAdvance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace LabExerciseAdvance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        //LabExerciseDBContext _context;
        PersonRepository _repo;

        public PersonController(/*,LabExerciseDBContext context*/)
        {
            //_context = context;
            _repo = new PersonRepository();
        }
        
        // GET: api/[controller]
        [HttpGet] 
        public ActionResult Get()
        {
            try
            {
                var results = _repo.GetList;

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // POST: api/[controller]/
        [HttpPost]
        public ActionResult Post(Dictionary<string,object> model)
        {
            try
            {
                string values = "";
                values += model["firstName"] + "|";
                values += model["lastName"] + "|";
                values += model["dateOfBirth"] + "|";
                values += model["gender"] + "|";
                values += model["status"] + "|";
                values += model["city"] + "|";
                if (model.ContainsKey("other"))
                {
                    values += model["other"] + "|";
                }
                if (model.ContainsKey("other2"))
                {
                    values += model["other2"];
                }

                string[] person = values.Split('|');

                _repo.Validate(person);
                _repo.Add(person);
                
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
