using webapi_dotnet_core_doc_swagger.Model;
using System.Collections.Generic;

namespace webapi_dotnet_core_doc_swagger.Business
{
    public interface IPersonBusiness
    {
    Person Create(Person person);  
    Person FindById(long id);  
    List< Person> FindAll(); 
    Person Update(Person person); 
    void Delete (long id);
    
    bool Exists(long? id);
    }
}