using FoxMinded;

namespace FoxMindedTests
{
    public class RowItemParserTests
    {
        private readonly RowItemParser _parser;

        public RowItemParserTests() 
        {
            this._parser = new RowItemParser();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("incorrect value")]
        [InlineData(".")]
        [InlineData("7a")]
        public void ParseInvalidTest(string item)
        {
            // Arrange
            var exceptionMessage = "Row contains incorrect values";

            // Act
            Action act = () => { this._parser.Parse(item); };

            // Assert
            var exception = Assert.Throws<IncorrectRowException>(act);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3",3)]
        [InlineData("3.5", 3.5)]
        [InlineData("4.5", 4.5)]
        [InlineData("5.6", 5.6)]
        [InlineData("6.7", 6.7)]
        public void ParseValidTest(string item, decimal expected) 
        {
            // Arrange

            // Act
            var actual = this._parser.Parse(item);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
