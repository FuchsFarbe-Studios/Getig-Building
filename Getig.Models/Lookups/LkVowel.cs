// Getig-Building
// LkVowel.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 05-11-2023

namespace Getig.Models.Lookups
{
    public class LkVowel : LkPhoneme
    {
        public bool Rounded { get; set; }
        public string Frontness { get; set; }
        public string Closeness { get; set; }
    }
}