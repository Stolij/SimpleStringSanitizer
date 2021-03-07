using System.Linq;

namespace SimpleStringSanitizer
{
    public class BlacklistStringSanitizer : ListSanitizerBase
    {
        public BlacklistStringSanitizer(string characterList) : base(characterList)
        { }

        /// <summary>
        /// Sanitizes a string based on the given disallowed characters.
        /// </summary>
        /// <param name="input">The string to be sanitized</param>
        /// <returns>A sanitized version of the string, with blacklisted characters removed</returns>
        public override string SanitizeString(string input)
        {
            return CharacterList.Aggregate(input, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        /// <summary>
        /// Sanitize the string, and return whether or not it was necessary.
        /// </summary>
        /// <param name="input">The string to be sanitized</param>
        /// <param name="result">The output variable</param>
        /// <returns>Whether or not sanitization was needed.</returns>
        public override bool SanitizeStringIfNecessary(string input, out string result)
        {
            result = SanitizeString(input);
            return result.SequenceEqual(input);
        }
    }
}