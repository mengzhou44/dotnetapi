
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
 using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace dotnetapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
              var executingAssembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
      
              var builder =  new ConfigurationBuilder()
                          .SetBasePath(executingAssembly.Directory.FullName)
                          .AddEnvironmentVariables()
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                                        
             Configuration = builder.Build();  
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
              var connectionString = Configuration.GetConnectionString("DbConnection");
              services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Scoped);

              services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
