namespace Getig.Models.Language
{
    /// <summary>
    ///     Represents a syllable, a unit of sound typically larger than a phoneme, in a language.
    ///     It has a specific phoneme pattern and belongs to a specific word.
    /// </summary>
    public class Syllable
    {
        public int Id { get; set; }
        public string Pattern { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}