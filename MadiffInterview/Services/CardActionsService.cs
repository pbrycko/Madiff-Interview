namespace MadiffInterview.Services
{
    public class CardActionsService
    {
        private readonly IReadOnlyList<CardAction> _actions;

        public CardActionsService(IEnumerable<CardAction> actions)
        {
            var duplicateAction = actions.GroupBy(action => action.ActionName).FirstOrDefault(group => group.Count() > 1);
            if (duplicateAction is not null)
            {
                throw new InvalidOperationException($"Action with name {duplicateAction.Key} is registered more than once");
            }

            _actions = actions.ToList();
        }

        public IEnumerable<CardAction> GetActionsForCard(CardDetails cardDetails)
        {
            ArgumentNullException.ThrowIfNull(cardDetails);

            return _actions.Where(action => action.IsCardAllowed(cardDetails));
        }
    }
}
