using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMvc(routes => {
                    //routes.MapRoute(
                    //     name: "NewRoute",
                    //    template: "App/Do{action}",
                    //    defaults: new { controller = "Home" });

                    routes.MapRoute(
                             name: "default",
                             template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "out",
                    template: "outbound/{controller=Home}/{action}=Index"); 
                        
                });      
            }
        }
    }
}


// You can create a url that will have static members or you can creatre a url that can have both static and variable elements. 

//routes.MapRoute(
//        name: "ShopSchema2",
//        template: "Shop/OldAction",
//        defaults: new { controller = "Home", action = "Index" }
//        );

//    routes.MapRoute(
//        name: "ShopSchema",
//        template: "Shop/{action}",
//        defaults: new { controller = "Home" }); 

//    routes.MapRoute("", "X{controller}/{action}");

//    routes.MapRoute(
//        name: "default",
//        template: "{controller=Home}/{action=Index}");

//    routes.MapRoute(
//        name: "default",
//        template: "Public/{controller=Home}/{action=Index}");

//This has three segements and the last segment will fall back on the default if the third segment is not present in the url 
//routes.MapRoute(
//              name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}/{id=DefaultId}"
//                    );

//A catchall that will grab all of the segments that are not assigned with the * character 
//routes.MapRoute(
//                name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}"
//                    );

//Inline constraint will seperated by the : character
//routes.MapRoute(
//               name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}/{id:int??"
//                    );


// inline constraint example. 
//app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}/{id:int?",
//                    );
//            });

// Using the regex so that the url has to start with an H
//app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "MyRoute",
//                    template: "{controller:regex(^H.*)=Home}/{action=Index}/{id:int?"
//                    );
//            });


// Putting constraints on the controller and the action. So that the controller will have to start with the letter H and the action can only be Index or About
//app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "MyRoute",
//                    template: "{controller:regex(^H.*)=Home}/" + 
//                    "{action:regex(^Index$|About$)=Index}/{id?}"
//                    );
//            });

// Using type and value constraints 
//app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");
//            });

//combining constraints. This will only alow a url through that is not there or it has 6 alphanumeric characters
//app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "MyRoute",
//                    template: "{controller=Home}/{action=Index}" + "/{id:alpha:minlength(6)?}");
//            });

// 
//routes.MapRoute(
//name: "MyRoute",
//                    template: "{controller}/{action}/{id?}",
//                    defaults: new { controller = "Home", action = "Index" },
//                    constraints: new
//                    {
//                        id = new CompositeRouteConstraint(
//                                new IRouteConstraint[] {
//                                new AlphaRouteConstraint(),
//                                new MinLengthRouteConstraint(6)
//                                }
//                            )
//                    });

/// Maing my custom constraint an inline constraint using the ConfigureServices and mapping the constraint class 
///         services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));   
//app.UseMvc(routes =>
//            {
//            routes.MapRoute(
//                name: "MyRoute",
//                template: "{controller}/{action}/{id:weekday?}");
//            });