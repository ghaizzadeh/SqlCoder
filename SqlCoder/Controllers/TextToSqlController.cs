using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class TextToSqlController : Controller
   {
      private readonly OllamaService _ollamaService;


      public TextToSqlController(OllamaService ollamaService)
      {
         _ollamaService = ollamaService;
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] PromptInput input)
      {

         var prompt=input.Prompt;
         var sql = await _ollamaService.GenerateSqlAsync(prompt);
         return Ok(new { sql });
      }
   }
   // Models/PromptInput.cs
   public class PromptInput
   {
      public string Prompt { get; set; }
   }
}

