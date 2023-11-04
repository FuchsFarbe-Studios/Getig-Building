namespace Getig.Models.Lang
{
    /// <summary>
    ///     Represents a phoneme, the smallest unit of sound, in a language.
    /// </summary>
    public class Phoneme
    {
        public int PhonemeId { get; set; }
        public string Sound { get; set; }
        public int ConLangId { get; set; }
        public ConLang ConLang { get; set; }
    }

}
