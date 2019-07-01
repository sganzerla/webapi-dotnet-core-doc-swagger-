using Microsoft.EntityFrameworkCore;
using webapi_dotnet_core_doc_swagger.Model;
using System.Linq;
using System.Collections.Generic;

namespace webapi_dotnet_core_doc_swagger.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){

        }
        public MySQLContext(DbContextOptions<MySQLContext> options): base (options){}

        public DbSet<Person> Persons {get;set;}
    }
}