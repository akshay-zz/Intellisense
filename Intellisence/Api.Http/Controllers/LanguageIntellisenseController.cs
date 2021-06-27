using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Http.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class LanguageIntellisenseController : ControllerBase
	{
        private IMonacoSuggestionRepository _suggestionRepository;

		public LanguageIntellisenseController(IMonacoSuggestionRepository monacoSuggestionRepository)
		{
            _suggestionRepository = monacoSuggestionRepository;
		}

        [HttpPost]
        [Route("GetAutoCompletion")]
        public async Task<IActionResult> GetAutoCompletion(CodeForSuggestionDto code)
        {
            try
            {
                var suggestion = await _suggestionRepository.GetMonacoSuggestion(code);
                ResultSuggestionDto result = new ResultSuggestionDto()
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = new Result()
                    {
                        Suggestions = suggestion
                    }
                };

                return Ok(result);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("GetBasicAutoCompletion")]
        public async Task<IActionResult> GetBasicAutoCompletion([FromBody] LanguageForSuggestion lang)
        {
            try
            {
                var suggestion = await _suggestionRepository.GetBasicSuggestion();
                ResultSuggestionDto result = new ResultSuggestionDto()
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = new Result()
                    {
                        Suggestions = suggestion
                    }
                };

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500 , ex.Message);
            }
        }
    }
}
