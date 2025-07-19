using MadiffInterview.Services;
using Microsoft.AspNetCore.Mvc;

namespace MadiffInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            WebApplication app = builder.Build();

            app.MapGet("/user/{userId:required}/card/{cardNumber:required}/actions", async (
                [FromRoute] string userId,
                [FromRoute] string cardNumber,
                [FromServices] CardService cardService,
                [FromServices] CardActionsService cardActionsService) =>
            {
                var card = await cardService.GetCardDetails(userId, cardNumber);
                if (card == null)
                {
                    return Results.NotFound();
                }

                var allowedActions = cardActionsService.GetActionsForCard(card);
                var allowedActionNames = allowedActions.Select(action => action.ActionName);
                return Results.Ok(allowedActionNames);
            });

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<CardService>();

            services.AddTransient<CardActionsService>();
            services.RegisterCardActions();
        }
    }
}
