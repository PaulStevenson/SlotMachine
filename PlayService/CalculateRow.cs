using System;
using System.Collections.Generic;
using System.Linq;
using PlayService.Interfaces;
using PlayService.Models;

namespace PlayService
{
    public class CalculateRow : ICalculateRow
    {
        private readonly string Wildcard = "*";

        public CalculateRow()
        {
        }

        public void CalculateIfRowIsWin(List<Row> rows)
        {
            foreach (var row in rows)
            {
                if (row.Symbols.Any(x => x.SlotSymbol == Wildcard))
                {
                    row.IsWIn = row.Symbols.Select(x => x.SlotSymbol).Distinct().Count() < 3;
                }
                else
                {
                    row.IsWIn = row.Symbols.Select(x => x.SlotSymbol).Distinct().Count() < 2;
                }
            }
        }

        public void SumCoefficient(List<Row> rows)
        {
            foreach (var row in rows)
            {
                row.Coefficient = row.Symbols.Sum(x => x.Coefficient);
                Math.Round(row.Coefficient, 2);
            }
        }
    }
}
