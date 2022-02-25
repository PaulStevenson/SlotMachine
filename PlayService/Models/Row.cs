using System.Collections.Generic;

namespace PlayService.Models
{
    public class Row
    {
        public List<ISymbol> Symbols { get; set; }

        public bool IsWIn { get; set; } = false;

        public double Coefficient { get; set; }
    }
}
