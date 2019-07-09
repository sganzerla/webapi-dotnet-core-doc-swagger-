using Microsoft.AspNetCore.Mvc;
using webapi_dotnet_core_doc_swagger.Model;
using webapi_dotnet_core_doc_swagger.Business;


namespace webapi_dotnet_core_doc_swagger.Controllers
{
    // há tres formas de versionar api
    // por convenção
    // por path/Route
    // por namespace
     /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    dote expõe como endpoint REST
    */
    
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")] 
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness){
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public  IActionResult Get()
        {
           return Ok();
           // return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            var person=_personBusiness.FindById(id);
            if(person==null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult  Post([FromBody] Person person)
        {
              if(person==null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
             if(person==null) return BadRequest();
             var updatePerson = _personBusiness.Update(person);
             if (updatePerson == null) return BadRequest();
            return new ObjectResult(updatePerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
