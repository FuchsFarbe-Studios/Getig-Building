namespace Getig.Models.Lang
{
    /// <summary>
    ///     Represents a syllable, a unit of sound typically larger than a phoneme, in a language.
    ///     It has a specific phoneme pattern and belongs to a specific word.
    /// </summary>
    public class Syllable
    {
        public int SyllableId { get; set; }
        public string Pattern { get; set; }
        public int ConLangId { get; set; }
        public ConLang ConLang { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}
