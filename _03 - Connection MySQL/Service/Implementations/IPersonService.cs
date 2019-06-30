using _02___Different_Verbs.Model;
using System.Collections.Generic;

namespace _02___Different_Verbs.Service.Implementations
{
    public interface IPersonService
    {
    Person Create(Person person);  
    Person FindById(long id);  
    List< Person> FindAll(); 
    Person Update(Person person); 
    void Delete (long id);
    
    }
}