using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using webapi_dotnet_core_doc_swagger.Business;
using webapi_dotnet_core_doc_swagger.Business.Implementations;
using webapi_dotnet_core_doc_swagger.Model.Context;
using webapi_dotnet_core_doc_swagger.Repository;
using webapi_dotnet_core_doc_swagger.Repository.Implementations;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;

namespace webapi_dotnet_core_doc_swagger
{
    public class Startup
    { 
         private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
             var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            //Adding Migrations Support
            ExecuteMigrations(connectionString);
                        
           
            // injeção de dependências         
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
         private void ExecuteMigrations(string connectionString)
        {
            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve("Evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }
            
        }

    }
}
