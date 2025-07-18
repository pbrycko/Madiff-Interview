using MadiffInterview.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MadiffInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            WebApplication app = builder.Build();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.TryAddSingleton<CardService>();
        }
    }
}
