namespace MadiffInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            WebApplication app = builder.Build();

            app.Run();
        }
    }
}
