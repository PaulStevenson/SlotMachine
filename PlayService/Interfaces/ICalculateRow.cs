using System.Collections.Generic;
using PlayService.Models;

namespace PlayService.Interfaces
{
    public interface ICalculateRow
    {
        void CalculateIfRowIsWin(List<Row> row);

        void SumCoefficient(List<Row> row);
    }
}
