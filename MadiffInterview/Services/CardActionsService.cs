namespace MadiffInterview.Services
{
    public class CardActionsService
    {
        private readonly IReadOnlyList<CardAction> _actions;
        private readonly ILogger _log;

        public CardActionsService(IEnumerable<CardAction> actions, ILogger<CardActionsService> log)
        {
            var duplicateAction = actions.GroupBy(action => action.ActionName).FirstOrDefault(group => group.Count() > 1);
            if (duplicateAction is not null)
            {
                throw new InvalidOperationException($"Action with name {duplicateAction.Key} is registered more than once");
            }

            _actions = actions.ToList();
            _log = log;
        }

        public IEnumerable<CardAction> GetActionsForCard(CardDetails cardDetails)
        {
            ArgumentNullException.ThrowIfNull(cardDetails);

            _log.LogInformation("Getting available actions for card {CardNumber}", cardDetails.CardNumber);
            return _actions.Where(action => action.IsCardAllowed(cardDetails));
        }
    }
}
