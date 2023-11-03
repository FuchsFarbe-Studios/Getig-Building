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

}