namespace Getig.Models.Language
{
    /// <summary>
    ///     Represents a phoneme, the smallest unit of sound, in a language.
    /// </summary>
    public class Phoneme
    {
        public int Id { get; set; }
        public string Sound { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }

    public class Element
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Category { get; set; }// e.g., "noun", "verb", "adjective" etc.
        public ICollection<GrammarRuleElement> GrammarRuleElements { get; set; }
    }

    public class GrammarRuleElement
    {
        public int GrammarRuleId { get; set; }
        public GrammarRule GrammarRule { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; }
        public int Order { get; set; }// to keep the order of elements
    }

    public class GrammarRule
    {
        public Guid GrammarID { get; set; }
        public string Description { get; set; }
        public ICollection<GrammarRuleElement> Elements { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}