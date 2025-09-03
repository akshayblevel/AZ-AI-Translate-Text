namespace AZ_AI_Translate_Text.Models
{
    public class TranslateRequest
    {
        public string Text { get; set; } = string.Empty;
        public string To { get; set; } = "en"; // target language
    }
}
