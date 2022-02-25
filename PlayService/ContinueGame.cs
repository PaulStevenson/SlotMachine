using System.Collections.Generic;
using System.Linq;
using PlayService.Interfaces;

namespace PlayService.Models
{
    public class ContinueGame : IContinueGame
    {
        public bool CanPlayAgain(int balance)
        {
            return balance > 0;
        }

        public int UpdateBalanceMinusStake(int balance, int stake)
        {
            return balance - stake;
        }

        public int CalculateWin(List<Row> rows, int stake)
        {
            var totalWinAmount = new List<int>();

            foreach (var row in rows)
            {
                var amount = (int)(stake * row.Coefficient);
                totalWinAmount.Add(amount);
            }

            return totalWinAmount.Sum(x => x);
        }

        public int UpdateBalanceWithWin(int balance, int win)
        {
            return balance + win;
        }

    }
}
