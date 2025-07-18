using MadiffInterview;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CardActionsServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCardAction(this IServiceCollection services, string actionName, Action<CardActionConditions> conditionsBuilder)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentException.ThrowIfNullOrWhiteSpace(actionName);
            ArgumentNullException.ThrowIfNull(conditionsBuilder);

            CardActionConditions conditions = new CardActionConditions();
            conditionsBuilder(conditions);

            services.AddTransient(_=> new CardAction(actionName, conditions));

            return services;
        }
    }
}
