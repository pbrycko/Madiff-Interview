using MadiffInterview.Services;

namespace MadiffInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);
            RegisterCardActions(builder.Services);

            WebApplication app = builder.Build();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<CardService>();
            services.AddTransient<CardActionsService>();
        }

        private static void RegisterCardActions(IServiceCollection services)
        {
            // actions and their conditions provided in the task's document
            services.RegisterCardAction("ACTION1", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION2", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Inactive));

            services.RegisterCardAction("ACTION3", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Restricted)
                .AllowCardStatus(CardStatus.Blocked)
                .AllowCardStatus(CardStatus.Expired)
                .AllowCardStatus(CardStatus.Closed));

            services.RegisterCardAction("ACTION4", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Restricted)
                .AllowCardStatus(CardStatus.Blocked)
                .AllowCardStatus(CardStatus.Expired)
                .AllowCardStatus(CardStatus.Closed));

            services.RegisterCardAction("ACTION5", conditions => conditions
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Restricted)
                .AllowCardStatus(CardStatus.Blocked)
                .AllowCardStatus(CardStatus.Expired)
                .AllowCardStatus(CardStatus.Closed));

            services.RegisterCardAction("ACTION6", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Inactive, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Active, card => card.IsPinSet)
                .AllowCardStatus(CardStatus.Blocked, card => card.IsPinSet));

            services.RegisterCardAction("ACTION7", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Inactive, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Active, card => !card.IsPinSet)
                .AllowCardStatus(CardStatus.Blocked, card => card.IsPinSet));

            services.RegisterCardAction("ACTION8", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Blocked));

            services.RegisterCardAction("ACTION9", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active)
                .AllowCardStatus(CardStatus.Restricted)
                .AllowCardStatus(CardStatus.Blocked)
                .AllowCardStatus(CardStatus.Expired)
                .AllowCardStatus(CardStatus.Closed));

            services.RegisterCardAction("ACTION10", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION11", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION12", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));

            services.RegisterCardAction("ACTION13", conditions => conditions
                .AllowCardType(CardType.Prepaid)
                .AllowCardType(CardType.Debit)
                .AllowCardType(CardType.Credit)
                .AllowCardStatus(CardStatus.Ordered)
                .AllowCardStatus(CardStatus.Inactive)
                .AllowCardStatus(CardStatus.Active));
        }
    }
}
