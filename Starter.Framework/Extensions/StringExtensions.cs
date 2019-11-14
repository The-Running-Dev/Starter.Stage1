using System;

namespace Starter.Framework.Extensions
{
    /// <summary>
    /// Defines extension methods for String types
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Compares two strings for equality, ignoring case
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string first, string second)
        {
            return string.Compare(first, second, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        /// <summary>
        /// Check if string is empty, null or white space
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string first)
        {
            return string.IsNullOrEmpty(first) || string.IsNullOrWhiteSpace(first);
        }
    }
}