using System;
using System.Collections.Generic;
using PlayService.Models;

namespace PlayService.Interfaces
{
    public interface IContinueGame
    {
        bool CanPlayAgain(int balance);

        int UpdateBalanceMinusStake(int balance, int stake);

        int CalculateWin(List<Row> rows, int stake);

        int UpdateBalanceWithWin(int balance, int win);
    }
}
