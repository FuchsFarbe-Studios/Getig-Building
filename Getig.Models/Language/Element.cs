namespace Getig.Models.Language
{
    public class Element
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Category { get; set; }// e.g., "noun", "verb", "adjective" etc.
        public ICollection<GrammarRuleElement> GrammarRuleElements { get; set; }
    }
}
