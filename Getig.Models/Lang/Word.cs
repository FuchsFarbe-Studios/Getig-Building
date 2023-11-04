namespace Getig.Models.Lang
{
    /// <summary>
    ///     Represents a word in a language. Each word is defined by its own syllable and belongs to a specific language.
    /// </summary>
    public class Word
    {
        public int WordId { get; set; }
        public string Value { get; set; }
        public int SyllableId { get; set; }
        public Syllable Syllable { get; set; }
        public int ConLangId { get; set; }
        public ConLang ConLang { get; set; }
    }
}
