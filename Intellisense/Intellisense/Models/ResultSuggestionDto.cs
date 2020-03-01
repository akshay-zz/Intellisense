using System.Net;

namespace Intellisense.Models
{
    public class ResultSuggestionDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public Result Result { get; set; }
    }
    public class Result
    {
        public string Suggestions { get; set; }
    }
}