using AZ_AI_Translate_Text.Interfaces;
using AZ_AI_Translate_Text.Models;
using Microsoft.AspNetCore.Mvc;

namespace AZ_AI_Translate_Text.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController(ITranslateService translateService) : ControllerBase
    {
        [HttpPost("Translate")]
        public async Task<IActionResult> SentimentAnalysis([FromBody] TranslateRequest translateRequest)
        {
            var result = await translateService.TranslateAsync(translateRequest);
            return Ok(result);
        }
    }
}
