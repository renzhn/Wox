using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wox.Infrastructure
{
    public class StringMatcher
    {
        /// <summary>
        /// Check if a candidate is match with the source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="candidate"></param>
        /// <returns>Match score</returns>
        public static int Match(string source, string candidate)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(candidate)) return 0;

            source = source.ToLower();
            candidate = candidate.ToLower();

            if (source == candidate)
            {
                return 50;
            }
            else if (source.StartsWith(candidate))
            {
                return 30;
            }
            else if (source.Contains(candidate)) {
                return 10;
            }

            return 0;
        }

        public static bool IsMatch(string source, string candidate)
        {
            return Match(source, candidate) > 0;
        }
    }
}
