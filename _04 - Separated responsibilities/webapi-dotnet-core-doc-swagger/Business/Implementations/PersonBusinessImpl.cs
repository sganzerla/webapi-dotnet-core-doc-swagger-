
using System.Collections.Generic;
using webapi_dotnet_core_doc_swagger.Model;
using webapi_dotnet_core_doc_swagger.Repository;
using System.Linq;

namespace webapi_dotnet_core_doc_swagger.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {            
            return _repository.Create(person);
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person Update(Person person)
        {          
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exists (long? id){
            return false;
        }
        
    }

    }