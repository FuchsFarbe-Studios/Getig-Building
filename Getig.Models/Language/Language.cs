namespace Getig.Models.Language
{
    /// <summary>
    ///     Model representing a spoken language. It contains collections of phonemes, syllables, words, and orthography rules that define the language.
    /// </summary>
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Phoneme> Phonemes { get; set; }
        public ICollection<Syllable> Syllables { get; set; }
        public ICollection<Word> Words { get; set; }
        public ICollection<OrthographyRule> OrthographyRules { get; set; }
    }
}
