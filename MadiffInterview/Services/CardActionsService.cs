namespace MadiffInterview.Services
{
    public class CardActionsService
    {
        private readonly List<CardAction> _actions = new List<CardAction>();

        public CardActionsService(IEnumerable<CardAction> actions)
        {
            foreach (var action in actions)
            {
                if (_actions.Any(a => a.ActionName == action.ActionName))
                    throw new InvalidOperationException($"Action with name {action.ActionName} is registered more than once");

                _actions.Add(action);
            }
        }

        public IEnumerable<CardAction> GetActionsForCard(CardDetails cardDetails)
        {
            ArgumentNullException.ThrowIfNull(cardDetails);

            return _actions.Where(action => action.IsCardAllowed(cardDetails));
        }
    }
}
