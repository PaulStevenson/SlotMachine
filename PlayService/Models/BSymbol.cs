namespace PlayService.Models
{
    public class BSymbol : ISymbol
    {
        public string SlotSymbol { get; } = "B";

        public double Coefficient { get; } = 0.6;

        public int Probability { get; } = 35;
    }
}
