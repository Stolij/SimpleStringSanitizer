using System;
using System.Linq;
using NUnit.Framework;
using SimpleStringSanitizer;

namespace SanitizerTest
{
    [TestFixture]
    public class Tests
    {
        private const string DisallowedCharacters = "\"|;$@!#%^&*()-=_+[{}]\\/.,~`<>";
        private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        
        private IStringSanitizer _sanitizerBlacklist = new BlacklistStringSanitizer(DisallowedCharacters);
        private IStringSanitizer _sanitizerWhitelist = new WhitelistStringSanitizer(AllowedCharacters);
        
        [Test]
        public void Test1()
        {
            AssertSanitization("\"'|getenv", _sanitizerWhitelist);
            AssertSanitization("\"tes<t> do(es) th!is wo^&rk?", _sanitizerBlacklist);
        }

        private void AssertSanitization(string input, IStringSanitizer sanitizer)
        {
            string result = sanitizer.SanitizeString(input);
            bool necessary = sanitizer.SanitizeStringIfNecessary(input, out string result2);
            
            Console.WriteLine("--------< Sanitization Test >--------");
            Console.WriteLine($"Unsanitized: '{input}'");
            Console.WriteLine($"Sanitized  : '{result}'");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            switch (sanitizer)
            {
                case BlacklistStringSanitizer blacklistStringSanitizer:
                    Assert.That(result.All(c => !blacklistStringSanitizer.CharacterList.Contains(c)));
                    break;
                case WhitelistStringSanitizer whitelistStringSanitizer:
                    Assert.That(result.All(c => whitelistStringSanitizer.CharacterList.Contains(c)));
                    break;
            }
        }
    }
}