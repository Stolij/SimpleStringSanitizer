namespace SimpleStringSanitizer
{
    public abstract class ListSanitizerBase : IStringSanitizer
    {
        public string CharacterList { get; set; }
        
        public ListSanitizerBase(string characterList)
        {
            CharacterList = characterList;
        }

        public abstract string SanitizeString(string input);
        public abstract bool SanitizeStringIfNecessary(string input, out string result);
    }
}