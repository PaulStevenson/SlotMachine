namespace PlayService.Models
{
    public class WildcardSymbol : ISymbol
    {
        public string SlotSymbol { get; } = "*";

        public double Coefficient { get; } = 0;

        public int Probability { get; } = 5;
    }
}
