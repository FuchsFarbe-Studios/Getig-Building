namespace Getig.Models.Language
{
    /// <summary>
    ///     Represents an Orthography Rule in a language. It's a transformation rule
    ///     for phoneme sequences to specific spellings.
    /// </summary>
    public class OrthographyRule
    {
        public int Id { get; set; }
        public string MatchPattern { get; set; }
        public string Replacement { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
