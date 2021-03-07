namespace SimpleStringSanitizer
{
    public interface IStringSanitizer
    {
        string SanitizeString(string input);
        bool SanitizeStringIfNecessary(string input, out string result);
    }
}