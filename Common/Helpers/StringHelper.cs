using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class StringHelper
    {
        public static bool StringsCloselyMatch_IgnoreCase(string first, string second)
        {
            return (DamerauLevenshtein.Distance(first.ToLower().Trim(),
                second.ToLower().Trim()) <= 2);
        }

        public static bool StringsCloselyMatch_IgnoreCaseAndNonAlphaNumeric(string first, string second)
        {
            return StringsCloselyMatch_IgnoreCase(StripNonAlphaNumeric(first), StripNonAlphaNumeric(second));
        }

        private static string StripNonAlphaNumeric(string text)
        {
            return Regex.Replace(text, "[^a-zA-Z0-9]", "");
        }
    }
}
