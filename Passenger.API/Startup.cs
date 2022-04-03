using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Passenger.API.Model;
using Passenger.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PassengerContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));
            services.AddScoped<PassengerContext>(); 
            services.AddTransient<IPassengerRespository, PassengerRespository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);

            //cache.Set("passengerKey", new List<Passenger.API.Model.Passenger> { new Model.Passenger { Id=Guid.NewGuid(), DocumentNo="T1",DocumentType= "pasaport",Gender="female",IssueDate=DateTime.Now,Name="Test1",Surname="AA" },
            //new Model.Passenger { Id=Guid.NewGuid(), DocumentNo="T12",DocumentType= "visa",Gender="male",IssueDate=DateTime.Now,Name="Test2",Surname="BB" }}, entryOptions);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
