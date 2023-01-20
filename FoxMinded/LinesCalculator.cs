namespace FoxMinded
{
    public class LinesCalculator
    {
        private readonly RowItemParser _rowParser;

        public LinesCalculator()
        {
            _rowParser = new RowItemParser();
        }

        public void CalculateLines(string[] lines, out List<int> wrongLinesList, out decimal maxRowValue, out int maxRow)
        {
            wrongLinesList = new List<int>();
            maxRow = 0;
            maxRowValue = decimal.MinValue;

            for (var i = 0; i < lines?.Length; i++)
            {
                decimal summary;
                var lineItems = lines[i].Split(',');

                try
                {
                    summary = lineItems.Sum(_rowParser.Parse);
                }
                catch (IncorrectRowException)
                {
                    wrongLinesList.Add(i + 1);

                    continue;
                }

                if (summary > maxRowValue)
                {
                    maxRowValue = summary;
                    maxRow = i + 1;
                }
            }
        }
    }
}
