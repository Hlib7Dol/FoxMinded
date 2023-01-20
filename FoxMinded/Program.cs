namespace FoxMinded
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = null;
            var linesReader = new LinesReader();

            while(lines == null)
            {
                var filePath = Console.ReadLine();

                lines = linesReader.ReadLines(filePath);
            }

            var linesCalculator = new LinesCalculator();

            linesCalculator.CalculateLines(lines, out List<int> wrongLinesList, out decimal maxRowValue, out int maxRow);

            Console.WriteLine($"Max row index: {maxRow}, max value: {maxRowValue}");
            Console.WriteLine($"Incorrect rows: {string.Join(',', wrongLinesList)}");

            Console.ReadKey();
        }
    }
}
