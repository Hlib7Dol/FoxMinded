namespace FoxMinded
{
    public class RowItemParser
    {
        public decimal Parse(string item)
        {
            var success = decimal.TryParse(item, out decimal value);

            if (!success)
            {
                throw new IncorrectRowException("Row contains incorrect values");
            }

            return value;
        }
    }
}
