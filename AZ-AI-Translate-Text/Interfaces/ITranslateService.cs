using AZ_AI_Translate_Text.Models;

namespace AZ_AI_Translate_Text.Interfaces
{
    public interface ITranslateService
    {
        Task<List<TranslationResult>> TranslateAsync(TranslateRequest translateRequest);
    }
}
