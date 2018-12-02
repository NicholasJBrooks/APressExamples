using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 

namespace ConfiguringApps
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } 

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<UpTimeService>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if ((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<bool>("EnableBrowserShortCircuit")).Value)
            {
                app.UseMiddleware<BrowserTypeMiddleware>();
                app.UseMiddleware<ShortCircuitMiddleware>(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); 
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
            }
            ///Allows the application to use the files in the wwwroot folder and will be nessesary for both development and production. 
            app.UseStaticFiles(); 
            app.UseMvcWithDefaultRoute();


              //Adding created middleware order matters the ones on the top will be the first to get teh request. 
             //app.UseMiddleware<BrowserTypeMiddleware>();
            //app.UseMiddleware<ShortCircuitMiddleware>();
           //app.UseMiddleware<ContentMiddleware>();
        }
    }
}
