using System.Net;

namespace Services.Models
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
