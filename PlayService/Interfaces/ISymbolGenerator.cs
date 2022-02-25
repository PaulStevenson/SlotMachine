using System.Collections.Generic;
using PlayService.Models;

namespace PlayService
{
    public interface ISymbolGenerator
    {
        List<Row> GenerateSymbols();
    }
}
