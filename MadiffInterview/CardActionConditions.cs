namespace MadiffInterview
{
    public class CardActionConditions
    {
        private readonly HashSet<CardType> _allowedCardTypes = new HashSet<CardType>();
        private readonly Dictionary<CardStatus, Func<CardDetails, bool>> _allowedCardStatuses = new Dictionary<CardStatus, Func<CardDetails, bool>>();

        public CardActionConditions AllowCardType(CardType cardType)
        {
            _allowedCardTypes.Add(cardType);
            return this;
        }

        public CardActionConditions AllowAllCardTypes()
        {
            foreach (var cardType in Enum.GetValues<CardType>())
                AllowCardType(cardType);

            return this;
        }

        public CardActionConditions AllowCardStatus(CardStatus cardStatus, Func<CardDetails, bool> additionalCondition)
        {
            ArgumentNullException.ThrowIfNull(additionalCondition);

            _allowedCardStatuses[cardStatus] = additionalCondition;
            return this;
        }

        public CardActionConditions AllowCardStatus(CardStatus cardStatus)
            => AllowCardStatus(cardStatus, _ => true);

        public CardActionConditions AllowAllCardStatuses()
        {
            foreach (var cardStatus in Enum.GetValues<CardStatus>())
                AllowCardStatus(cardStatus);

            return this;
        }

        public bool SatisfiedBy(CardDetails cardDetails)
            => _allowedCardTypes.Contains(cardDetails.CardType) 
            && _allowedCardStatuses.TryGetValue(cardDetails.CardStatus, out var additionalCondition) 
            && additionalCondition(cardDetails);
    }
}
