using MadiffInterview;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CardActionsServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCardActions(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            // actions and their conditions provided in the task's document
            services.RegisterCardAction("ACTION1", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION2", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Inactive));

            services.RegisterCardAction("ACTION3", conditions => conditions
                .AllowAllCardTypes()
                .AllowAllCardStatuses());

            services.RegisterCardAction("ACTION4", conditions => conditions
                .AllowAllCardTypes()
                .AllowAllCardStatuses());

            services.RegisterCardAction("ACTION5", conditions => conditions
                .AllowCardType(CardType.Credit)
                .AllowAllCardStatuses());

            services.RegisterCardAction("ACTION6", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Inactive, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Active, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Blocked, card => card.IsPinSet));

            services.RegisterCardAction("ACTION7", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Inactive, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Active, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Blocked, card => card.IsPinSet));

            services.RegisterCardAction("ACTION8", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Blocked));

            services.RegisterCardAction("ACTION9", conditions => conditions
                .AllowAllCardTypes()
                .AllowAllCardStatuses());

            services.RegisterCardAction("ACTION10", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION11", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION12", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION13", conditions => conditions
                .AllowAllCardTypes()
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            return services;
        }

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
