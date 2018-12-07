using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            //Overriding the defualt webHostBuilder to do it line by line. 
            //This way you will have moe flexability when you have to changethe configuration of the project

            return new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) => {
                   var env = hostingContext.HostingEnvironment; 
                   config.AddJsonFile("appsettings.json", 
                       optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                       optional: true , reloadOnChange: true);
                   config.AddEnvironmentVariables();
                   if (args != null)
                   {
                       config.AddCommandLine(args); 
                   }
               })
               .ConfigureLogging((hostingContext, logging) => {
                   logging.AddConfiguration(
                       hostingContext.Configuration.GetSection("Logging"));
                   logging.AddConsole();
                   logging.AddDebug(); 
               })
               .UseIISIntegration()
               .UseDefaultServiceProvider((context, options) => {
                   options.ValidateScopes =
                   context.HostingEnvironment.IsDevelopment(); 
               })
               .UseStartup(nameof(ConfiguringApps))
               .Build();
        }
    }
}   
