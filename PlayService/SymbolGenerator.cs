using System;
using System.Collections.Generic;
using PlayService.Models;

namespace PlayService
{
    public class SymbolGenertor : ISymbolGenerator
    {
        public List<Row> GenerateSymbols()
        {
            var listOfNumbers = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                listOfNumbers.Add(RandomNumberGenerator());
            }

            var listOfSymbols = SortNumbersToSymbols(listOfNumbers);

            var rows = SortSymbolsIntoRows(listOfSymbols);

            return rows;
        }

        private int RandomNumberGenerator()
        {

            var random = new Random();
            var number = random.Next(1, 100);

            return number;
        }

        private List<ISymbol> SortNumbersToSymbols(List<int> listOfNumbers)
        {
            /*
            Cumlative
                5% - Less than 6
                20% - P between 6 & 20
                55% - B between 21 & 55
                100% - Greater than 55
            */

            var listOfSymbols = new List<ISymbol>();

            foreach (var item in listOfNumbers)
            {
                if (item < 6)
                {
                    listOfSymbols.Add(new WildcardSymbol());
                }
                else if (item >= 6 && item < 21)
                {
                    listOfSymbols.Add(new PSymbol());
                }
                else if (item >= 21 && item < 56)
                {
                    listOfSymbols.Add(new BSymbol());
                }
                else
                {
                    listOfSymbols.Add(new ASymbol());
                }
            }

            return listOfSymbols;
        }

        private List<Row> SortSymbolsIntoRows(List<ISymbol> symbols)
        {
            var rows = new List<Row>();

            var rowOne = new Row();
            var rangeOne = symbols.GetRange(0, 3);
            rowOne.Symbols = rangeOne;

            var rowTwo = new Row();
            var rangeTwo = symbols.GetRange(3, 3);
            rowTwo.Symbols = rangeTwo;

            var rowThree = new Row();
            var rangeThree = symbols.GetRange(6, 3);
            rowThree.Symbols = rangeThree;

            rows.Add(rowOne);
            rows.Add(rowTwo);
            rows.Add(rowThree);

            return rows;
        }
    }
}
