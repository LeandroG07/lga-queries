using System.Text;

namespace LGA.Queries.Core.Extensions.Strings
{
    public static class StringExtensions
    {

        public static string Join(string? separator, string appendLeftText, string?[] values)
        {
            if (separator == null)
                throw new ArgumentNullException(nameof(separator));

            var sb = new StringBuilder();
            foreach(var value in values)
            {
                sb.Append($"{appendLeftText}{value}{separator}");
            }
            var text = sb.ToString();
            return text.Remove(text.Length - separator.Length, separator.Length);
        }

    }
}
