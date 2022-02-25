namespace PlayService.Models
{
    public interface ISymbol
    {
        public string SlotSymbol { get; }

        public double Coefficient { get; }

        public int Probability { get; }
    }
}
