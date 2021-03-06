using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GestaoQualidadeAutomotiva.API.PUC
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   var settings = config.Build();
                   config.AddAzureAppConfiguration(options =>
                   {
                       options.Connect(settings["ConnectionStrings:AppConfiguration"])
                           .ConfigureRefresh(refresh =>
                           {
                               refresh.Register("ClientId");
                               refresh.Register("Instance");
                               refresh.Register("ResourceId");
                               refresh.Register("TenantId");
                           });
                   });
               })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
               .UseDefaultServiceProvider(options => options.ValidateScopes = false);
    }
}
