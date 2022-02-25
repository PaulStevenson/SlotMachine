using PlayService;
using Xunit;

namespace TestGamePlayService
{
    public class TestSymbolGenerator
    {
        [Fact]
        public void ShouldPass_WhenGenerateSymbols_Returns3Rows()
        {
            var expectedRowCount = 3;
            var expectedSymbolCountPerRow = 3;

            var symbolGenertor = new SymbolGenertor();

            var result = symbolGenertor.GenerateSymbols();

            Assert.Equal(expectedRowCount, result.Count);
            Assert.Equal(expectedSymbolCountPerRow, result[0].Symbols.Count);
            Assert.Equal(expectedSymbolCountPerRow, result[1].Symbols.Count);
            Assert.Equal(expectedSymbolCountPerRow, result[2].Symbols.Count);
        }
    }
}
