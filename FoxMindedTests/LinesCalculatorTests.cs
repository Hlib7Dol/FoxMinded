using FoxMinded;

namespace FoxMindedTests
{
    public class LinesCalculatorTests
    {
        private readonly LinesCalculator _linesCalculator;

        public LinesCalculatorTests() 
        {
            _linesCalculator = new LinesCalculator();
        }

        [Theory, MemberData(nameof(GetLines))]
        public void CalculateLinesTest(string[] lines, List<int> expectedWrongLinesList, decimal expectedMaxRowValue, int expectedMaxRow)
        {
            // Arrange

            // Act
            this._linesCalculator.CalculateLines(lines, out List<int> wrongLinesList, out decimal maxRowValue, out int maxRow);

            // Assert
            Assert.Equal(expectedWrongLinesList, wrongLinesList);
            Assert.Equal(expectedMaxRowValue, maxRowValue);
            Assert.Equal(expectedMaxRow, maxRow);
        }

        public static IEnumerable<object[]> GetLines()
        {
            yield return new object[] { null, new List<int>(), decimal.MinValue, 0 };
            yield return new object[] { Array.Empty<string>(), new List<int>(), decimal.MinValue, 0 };
            yield return new object[] { new[] 
            { 
                "1,2,3,4",
                "5,6,7",
                "8,9",
                "10,11"
            }, new List<int>(), 21, 4 };
            yield return new object[] { new[]
            {
                "1,2,3,4",
                "5,6,7",
                "8,9",
            }, new List<int>(), 18, 2 };
            yield return new object[] { new[]
            {
                "1,2,3,4",
                "5,6,7f",
                "8,9",
            }, new List<int>() { 2 }, 17, 3 };
            yield return new object[] { new[]
            {
                "1,2,3,4",
                "5,6,7,",
                "8,9",
            }, new List<int>() { 2 }, 17, 3 };
            yield return new object[] { new[]
            {
                "1,2,3,4f",
                "5,6,7,",
                "8,9f",
            }, new List<int>() { 1, 2, 3 }, decimal.MinValue, 0 };
            yield return new object[] { new[]
            {
                "1,2,3,4",
                "5,6,7"
            }, new List<int>(), 18, 2 };
            yield return new object[] { new[]
            {
                "1,2,3,4"
            }, new List<int>(), 10, 1 };
            yield return new object[] { new[]
            {
                "1,2,3,4a"
            }, new List<int>() { 1 }, decimal.MinValue, 0 };
        }
    }
}