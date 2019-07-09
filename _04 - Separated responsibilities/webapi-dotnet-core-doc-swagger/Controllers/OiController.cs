using Microsoft.AspNetCore.Mvc;
using webapi_dotnet_core_doc_swagger.Model;
using webapi_dotnet_core_doc_swagger.Business;


namespace webapi_dotnet_core_doc_swagger.Controllers
{
        
    [ApiController]
    [Route("api/[controller]")] 
    public class OiController : BaseController
    {
        
        public OiController( ){
            
        }

        [HttpGet]
        public  int Get()
        {
           return  3;
        }

         
    }
}
