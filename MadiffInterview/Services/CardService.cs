namespace MadiffInterview.Services
{
    public class CardService
    {
        private readonly Dictionary<string, Dictionary<string, CardDetails>> _userCards;

        private readonly ILogger _log;

        public CardService(ILogger<CardService> log)
        {
            _log = log;
            _userCards = CreateSampleUserCards();
        }

        public async Task<CardDetails?> GetCardDetails(string userId, string cardNumber)
        {
            // At this point, we would typically make an HTTP call to an external service
            // to fetch the data. For this example we use generated sample data.
            await Task.Delay(1000);

            if (!_userCards.TryGetValue(userId, out var cards)
                || !cards.TryGetValue(cardNumber, out var cardDetails))
            {
                return null;
            }
            return cardDetails;
        }

        private Dictionary<string, Dictionary<string, CardDetails>> CreateSampleUserCards()
        {
            _log.LogInformation("Generating sample user cards");
            var userCards = new Dictionary<string, Dictionary<string, CardDetails>>();
            for (var i = 1; i <= 3; i++)
            {
                var userId = $"User{i}";
                _log.LogDebug("Generating cards for user {UserID}", userId);

                var cards = new Dictionary<string, CardDetails>();
                var cardIndex = 1;
                foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
                {
                    foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                    {
                        var cardNumber = $"Card{i}{cardIndex}";
                        var cardDetails = new CardDetails(
                                CardNumber: cardNumber,
                                CardType: cardType,
                                CardStatus: cardStatus,
                                IsPinSet: cardIndex % 2 == 0);
                        cards.Add(cardNumber, cardDetails);

                        // we log card details here solely in order to make manual-testing this code easier
                        _log.LogDebug("Generated card {CardNumber} for user {UserID} with type {CardType}, status {CardStatus} and IsPinSet {IsPinSet}",
                            cardDetails.CardNumber, userId, cardDetails.CardType, cardDetails.CardStatus, cardDetails.IsPinSet);

                        cardIndex++;
                    }
                }
                userCards.Add(userId, cards);
            }
            return userCards;
        }
    }
}
