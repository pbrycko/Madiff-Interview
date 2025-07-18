namespace MadiffInterview
{
    public record CardAction(string ActionName, CardActionConditions ActionConditions)
    {
        public bool IsCardAllowed(CardDetails cardDetails)
            => ActionConditions.SatisfiedBy(cardDetails);
    }
}
