namespace PlayService.Models
{
    public class ASymbol : ISymbol
    {
        public string SlotSymbol { get; } = "A";

        public double Coefficient { get; } = 0.4;

        public int Probability { get; } = 45;
    }
}
