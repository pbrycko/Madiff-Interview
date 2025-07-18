namespace MadiffInterview.UnitTests
{
    public class CardActionConditionsTests
    {
        [Fact]
        public void WhenNoConditions_ShouldRejectCard()
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, IsPinSet: false);
            var conditions = new CardActionConditions();

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeFalse();
        }

        [Fact]
        public void WhenAllowAll_ShouldAllowCard()
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, IsPinSet: false);
            var conditions = new CardActionConditions()
                .AllowAllCardTypes()
                .AllowAllCardStatuses();

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void WhenAllowCardTypeAndStatus_ShouldAllowCard()
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, IsPinSet: false);
            var conditions = new CardActionConditions()
                .AllowCardType(card.CardType)
                .AllowCardStatus(card.CardStatus);

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void WhenAllowCardType_ButDisallowStatus_ShouldRejectCard()
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, IsPinSet: false);
            var conditions = new CardActionConditions()
                .AllowCardType(card.CardType);

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeFalse();
        }

        [Fact]
        public void WhenAllowCardStatus_ButDisallowType_ShouldRejectCard()
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, IsPinSet: false);
            var conditions = new CardActionConditions()
                .AllowCardStatus(card.CardStatus);

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WhenAllowByCustomCondition_UsingIsPinSet_ShouldAllowWhenMatches(bool isPinSet)
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, isPinSet);
            var conditions = new CardActionConditions()
                .AllowCardType(card.CardType)
                .AllowCardStatus(card.CardStatus, c => c.IsPinSet == isPinSet);

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WhenAllowByCustomCondition_UsingIsPinSet_ShouldAllowWhenDoesNotMatch(bool isPinSet)
        {
            // Arrange
            var card = new CardDetails("Card111", CardType.Debit, CardStatus.Active, isPinSet);
            var conditions = new CardActionConditions()
                .AllowCardType(card.CardType)
                .AllowCardStatus(card.CardStatus, c => c.IsPinSet == !isPinSet);

            // Act
            var result = conditions.SatisfiedBy(card);

            // Arrange
            result.Should().BeFalse();
        }
    }
}