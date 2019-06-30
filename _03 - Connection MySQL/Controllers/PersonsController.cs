using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _02___Different_Verbs.Service.Implementations;
using _02___Different_Verbs.Model;
namespace webapi_dotnet_core_doc_swagger_.Controllers
{
    // há tres formas de versionar api
    // por convenção
    // por path/Route
    // por namespace
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1")]    
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService){
            _personService = personService;
        }

        [HttpGet]
        public  IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            var person=_personService.FindById(id);
            if(person==null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult  Post([FromBody] Person person)
        {
              if(person==null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
             if(person==null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
