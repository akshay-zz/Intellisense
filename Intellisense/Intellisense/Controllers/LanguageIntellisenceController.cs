using Intellisense.Data;
using Intellisense.Data.Interface;
using Intellisense.Dtos;
using Intellisense.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intellisense.Controllers
{
    [System.Web.Mvc.Route("api/[controller]/[action]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LanguageIntellisenseController : ApiController
    {
        private IMonacoSuggestionRepository _suggestionRepository;
        private readonly ISuggestionServiceProvider _serviceProvider;

        public LanguageIntellisenseController(ISuggestionServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // POST: api/<controller>
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> GetAutoCompletion(CodeForSuggestionDto code)
        {
            try
            {
                _suggestionRepository = _serviceProvider.GetService(
                    (SuggestionLanguage.Languages)Enum.Parse(
                        typeof(SuggestionLanguage.Languages),
                        code.Language)
                );

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
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }   
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> GetBasicAutoCompletion([FromBody]LanguageForSuggestion lang)
        {
            try
            {
                _suggestionRepository = _serviceProvider.GetService(
                    (SuggestionLanguage.Languages)Enum.Parse(
                        typeof(SuggestionLanguage.Languages),
                        lang.Language)
                );

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
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
