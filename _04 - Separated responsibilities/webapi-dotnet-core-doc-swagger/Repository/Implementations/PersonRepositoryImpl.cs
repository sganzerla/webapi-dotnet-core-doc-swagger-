
using System.Collections.Generic;
using webapi_dotnet_core_doc_swagger.Model;
using webapi_dotnet_core_doc_swagger.Model.Context;
using System.Linq;
using System;

namespace webapi_dotnet_core_doc_swagger.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return person;
        }
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person Update(Person person)
        {

            if (!Exists(person.Id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return person;
        }
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}