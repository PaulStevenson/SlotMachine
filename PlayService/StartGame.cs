using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PlayService.Interfaces;
using PlayService.Models;

namespace PlayService
{
    public class StartGame : IStartGame
    {
        private const string WelcomeMessage = "Welcome to Bede Slots. Good luck!";
        private const string ZeroBalanceMessage = "You've lost all your money.Bye bye.";
        private const string ExitMessage = "Press any button to exit.";
        private const string PlaceBet = "Please enter your bet amount.";
        private const string RectifyPlaceBet = "Please enter a number as your bet.";
        private const string PlaceStake = "Enter your stake.";
        private const string PlayAgain = "Press any button to enter you stake and spin again.";


        private readonly ISymbolGenerator _symbolGenerator;
        private readonly IContinueGame _continueGame;
        private readonly ICalculateRow _calculateRow;

        public StartGame(ISymbolGenerator symbolGenerator, IContinueGame continueGame, ICalculateRow calculateRow)
        {
            _symbolGenerator = symbolGenerator;
            _continueGame = continueGame;
            _calculateRow = calculateRow;
        }

        public void Start()
        {
            int balanceAmount;
            bool invalidInput = true;
            int stake;

            Console.WriteLine(WelcomeMessage);

            Console.WriteLine(PlaceBet);

            do
            {
                var depositResponse = Console.ReadLine();

                if (int.TryParse(depositResponse, out balanceAmount) && balanceAmount > 0)
                {
                    invalidInput = false;
                    Console.WriteLine($"You've bet {balanceAmount}.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(RectifyPlaceBet);
                }
            } while (invalidInput);

            var canPlay = _continueGame.CanPlayAgain(balanceAmount);

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine(PlaceStake);

                    var stakeResponse = Console.ReadLine();

                    if (int.TryParse(stakeResponse, out stake) && stake <= balanceAmount && stake > 0)
                    {
                        invalidInput = false;
                        Console.WriteLine($"You've bet {stake}.");
                    }
                    else
                    {
                        invalidInput = true;
                        Console.WriteLine();
                        Console.WriteLine($"Please enter a number lower than {balanceAmount} as your stake.");
                    }

                } while (invalidInput);

                var rows = _symbolGenerator.GenerateSymbols();

                SetUpAndDisplayRows(rows);

                balanceAmount = _continueGame.UpdateBalanceMinusStake(balanceAmount, stake);

                _calculateRow.CalculateIfRowIsWin(rows);

                var wins = rows.Where(r => r.IsWIn).ToList();

                if (wins.Count > 0)
                {
                    balanceAmount = ApplyWinnings(wins, stake, balanceAmount);
                }

                Console.WriteLine($"You're balance is {balanceAmount}");

                canPlay = _continueGame.CanPlayAgain(balanceAmount);

                if (canPlay)
                {
                    PlayingAgain();
                }
                else
                {
                    NotPlayingAgain();
                }

            } while (canPlay);
        }

        private void SetUpAndDisplayRows(List<Row> rows)
        {
            Console.WriteLine();

            var rowOne = new List<string>();
            rows[0].Symbols.ForEach(s => rowOne.Add(s.SlotSymbol));

            var rowTwo = new List<string>();
            rows[1].Symbols.ForEach(s => rowTwo.Add(s.SlotSymbol));

            var rowThree = new List<string>();
            rows[2].Symbols.ForEach(s => rowThree.Add(s.SlotSymbol));

            Console.WriteLine($"|{string.Join("|", rowOne)}|");
            Thread.Sleep(TimeSpan.FromSeconds(.5));
            Console.WriteLine($"|{string.Join("|", rowTwo)}|");
            Thread.Sleep(TimeSpan.FromSeconds(.5));
            Console.WriteLine($"|{string.Join("|", rowThree)}|");
            Thread.Sleep(TimeSpan.FromSeconds(.25));
            Console.WriteLine();
        }

        private int ApplyWinnings(List<Row> wins, int stake, int balanceAmount)
        {
            _calculateRow.SumCoefficient(wins);

            var winAmount = _continueGame.CalculateWin(wins, stake);

            Console.WriteLine($"You won {winAmount}");

            balanceAmount = _continueGame.UpdateBalanceWithWin(balanceAmount, winAmount);

            return balanceAmount;
        }

        private void PlayingAgain()
        {
            Console.WriteLine();
            Console.WriteLine(PlayAgain);
            Console.ReadLine();
        }

        private void NotPlayingAgain()
        {
            Console.WriteLine(ZeroBalanceMessage);
            Console.WriteLine(ExitMessage);
            Console.ReadLine();
        }
    }
}
