namespace Getig.Models.Lang
{
    public class GrammarRule
    {
        public Guid GrammarID { get; set; }
        public string Description { get; set; }
        public ICollection<GrammarRuleElement> GrammarRuleElements { get; set; }
        public int LanguageId { get; set; }
        public ConLang ConLang { get; set; }
    }
}
