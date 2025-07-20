using MadiffInterview.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadiffInterview.UnitTests
{
    public class CardActionsServiceTests
    {
        [Fact]
        public void WhenDuplicateActionNames_ShouldThrow()
        {
            // Arrange
            var log = Substitute.For<ILogger<CardActionsService>>();
            var name = "foobar";
            var actions = new CardAction[] 
            {
                new CardAction(name, new CardActionConditions()),
                new CardAction(name, new CardActionConditions()),
            };

            // Act
            Func<CardActionsService> act = () => new CardActionsService(actions, log);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void WhenCardSatisfiesActionsConditions_ShouldReturnActions()
        {
            // Arrange
            var log = Substitute.For<ILogger<CardActionsService>>();
            var card = new CardDetails("Card012", CardType.Credit, CardStatus.Active, IsPinSet: true);
            var actions = new CardAction[]
            {
                new CardAction("A1", new CardActionConditions().AllowCardType(CardType.Credit).AllowAllCardStatuses()),
                new CardAction("A2", new CardActionConditions().AllowAllCardTypes().AllowCardStatus(CardStatus.Active)),
                new CardAction("A3", new CardActionConditions().AllowAllCardTypes().AllowCardStatus(CardStatus.Active, card => card.IsPinSet))
            };
            var service = new CardActionsService(actions, log);

            // Act
            var results = service.GetActionsForCard(card);

            // Assert
            results.Should().HaveCount(actions.Length);
            results.Should().BeEquivalentTo(actions);
        }

        [Fact]
        public void WhenCardDoesNotSatisfyActionsConditions_ShouldNotReturnActions()
        {
            // Arrange
            var log = Substitute.For<ILogger<CardActionsService>>();
            var card = new CardDetails("Card012", CardType.Credit, CardStatus.Active, IsPinSet: true);
            var actions = new CardAction[]
            {
                new CardAction("A1", new CardActionConditions().AllowCardType(CardType.Debit).AllowAllCardStatuses()),
                new CardAction("A2", new CardActionConditions().AllowAllCardTypes().AllowCardStatus(CardStatus.Blocked)),
                new CardAction("A3", new CardActionConditions().AllowAllCardTypes().AllowCardStatus(CardStatus.Active, card => !card.IsPinSet))
            };
            var service = new CardActionsService(actions, log);

            // Act
            var results = service.GetActionsForCard(card);

            // Assert
            results.Should().BeEmpty();
        }
    }
}
