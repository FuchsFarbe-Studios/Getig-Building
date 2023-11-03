namespace Getig.Models.Language
{
    public class GrammarRule
    {
        public Guid GrammarID { get; set; }
        public string Description { get; set; }
        public ICollection<GrammarRuleElement> Elements { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
