using System.Text;

namespace LGA.Queries.Core.Extensions.Strings
{
    public static class StringBuilderExtensions
    {

        public static bool IsNullOrEmpty(this StringBuilder stringBuilder)
        {
            return (stringBuilder?.Length ?? 0) <= 0;
        }

    }
}
