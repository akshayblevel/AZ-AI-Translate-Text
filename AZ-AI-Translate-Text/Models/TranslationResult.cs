using System.Transactions;

namespace AZ_AI_Translate_Text.Models
{
    public class TranslationResult
    {
        public DetectedLanguage? DetectedLanguage { get; set; }
        public List<Translation>? Translations { get; set; }
    }
}
