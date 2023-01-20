using FoxMinded;

namespace FoxMindedTests
{
    public class LinesReaderTests
    {
        private readonly LinesReader _linesReader;

        public LinesReaderTests()
        {
            this._linesReader = new LinesReader();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Incorrect path")]
        public void LinesReaderInvalidTest(string path)
        {
            // Arrange

            // Act
            var lines = this._linesReader.ReadLines(path);

            // Assert
            Assert.Null(lines);
        }

        [Fact]
        public void LinesReaderValidTest()
        {
            // Arrange
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\test.txt";
            var expectedLines = new[] { "2.3,2,3.5" };

            // Act
            var actual = this._linesReader.ReadLines(path);

            // Assert
            Assert.Equal(expectedLines, actual);
        }
    }
}
