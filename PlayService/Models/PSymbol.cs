namespace PlayService.Models
{
    public class PSymbol : ISymbol
    {
        public string SlotSymbol { get; } = "P";

        public double Coefficient { get; } = 0.8;

        public int Probability { get; } = 15;
    }
}
