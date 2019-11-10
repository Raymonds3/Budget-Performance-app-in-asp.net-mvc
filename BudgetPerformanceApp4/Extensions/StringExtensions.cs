using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BudgetPerformanceApp4.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Splits a pascal-case string into words
        /// </summary>
        public static string Depascalise(this string value)
        {
            if (value == null) return null;
            if (string.IsNullOrWhiteSpace(value)) return "";

            var depascalised = Regex.Replace(value, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
            depascalised = depascalised.Replace(" and ", " & ", StringComparison.InvariantCultureIgnoreCase);

            return depascalised;
        }

        // <summary>
        /// Replaces all occurances of a string phrase
        /// From https://stackoverflow.com/questions/244531/is-there-an-alternative-to-string-replace-that-is-case-insensitive
        /// </summary>
        public static string Replace(this string value, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = value.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(value.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = value.IndexOf(oldValue, index, comparison);
            }
            sb.Append(value.Substring(previousIndex));

            return sb.ToString();
        }
    }
}