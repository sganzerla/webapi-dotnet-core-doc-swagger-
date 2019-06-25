
using System.Collections.Generic;
using System.Threading;
using _02___Different_Verbs.Model;
namespace _02___Different_Verbs.Service.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        
        private volatile int count;
        public Person Create(Person person){
            return new Person();
        } 
       public Person FindById(long id){
           return new Person(){
               Id=IncrementAndGet(),
               FirstName = "Yuri",
               LastName = "Sganzerla",
               Address = "Santa Maria",
               Gender = "Male"
               };
       }  
       public List< Person> FindAll(){
            var persons = new List<Person>();
            for (int i=0;i < 5; i++){
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
       }
       public Person Update(Person person){
           return person;
       }
       public void Delete (long id){

       }
       private Person MockPerson(int i){
            return new Person(){
               Id=IncrementAndGet(),
               FirstName = "Person First Name " + i,
               LastName = "Person Last Name " + i,
               Address = "Person Address " + 1,
               Gender = "Gender " + 1
               };
       }
       private long IncrementAndGet(){
           return Interlocked.Increment(ref count);
       }
    }
}