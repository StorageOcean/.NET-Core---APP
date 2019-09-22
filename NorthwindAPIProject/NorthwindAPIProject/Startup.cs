using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindAPIProject.Model;
using NorthwindAPIProject.Services;

namespace NorthwindAPIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddDbContext<NorthwindContext>(item => item.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));
            //var cadena = "DataSource=DESKTOP-6203HGC;Initial Catalog=Northwind;Integrated Security=True";
            
            services.AddDbContext<NorthwindContext>(item => item.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));
           // services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(cadena));
            services.AddScoped < IRepository, NorthwindRepository>();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
