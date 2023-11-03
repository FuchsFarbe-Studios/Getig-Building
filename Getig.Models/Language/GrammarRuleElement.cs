namespace Getig.Models.Language
{
    public class GrammarRuleElement
    {
        public int GrammarRuleId { get; set; }
        public GrammarRule GrammarRule { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; }
        public int Order { get; set; }// to keep the order of elements
    }
}
