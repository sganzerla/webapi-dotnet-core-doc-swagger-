
using System.Collections.Generic;
using System.Threading;
using _02___Different_Verbs.Model;
using _02___Different_Verbs.Model.Context;
using System.Linq;

namespace _02___Different_Verbs.Service.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
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

            if (!Exists(person.Id)) return new Person();
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

        private bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}