namespace FoxMinded
{
    public class LinesReader
    {
        public string[] ReadLines(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found by this path, try another one");

                return null;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Path argument is empty");

                return null;
            }
        }
    }
}
