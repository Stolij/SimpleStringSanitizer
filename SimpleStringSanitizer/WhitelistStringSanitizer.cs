using System.Linq;

namespace SimpleStringSanitizer
{
    public class WhitelistStringSanitizer : ListSanitizerBase
    {
        public WhitelistStringSanitizer(string characterList) : base(characterList)
        { }
        
        /// <summary>
        /// Sanitizes the input string by removing all items not present in the character list.
        /// </summary>
        /// <param name="input">The string to be sanitized</param>
        /// <returns>A sanitized version of the input string</returns>
        public override string SanitizeString(string input)
        {
            return input
                   .Distinct()
                   .Where(c => !CharacterList.Contains(c))
                   .Aggregate(input, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        /// <summary>
        /// Sanitizes the input string, and returns whether or not sanitization was necessary.
        /// </summary>
        /// <param name="input">The string to be sanitized</param>
        /// <param name="result">The variable to store the sanitized string in</param>
        /// <returns>Whether or not sanitization was needed</returns>
        public override bool SanitizeStringIfNecessary(string input, out string result)
        {
            result = SanitizeString(input);
            return result.Equals(input);
        }
    }
}