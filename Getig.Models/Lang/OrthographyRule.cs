namespace Getig.Models.Lang
{
    /// <summary>
    ///     Represents an Orthography Rule in a language. It's a transformation rule
    ///     for phoneme sequences to specific spellings.
    /// </summary>
    public class OrthographyRule
    {
        public int OrthographyRuleId { get; set; }
        public string MatchPattern { get; set; }
        public string Replacement { get; set; }
        public int ConLangId { get; set; }
        public ConLang ConLang { get; set; }
    }
}
