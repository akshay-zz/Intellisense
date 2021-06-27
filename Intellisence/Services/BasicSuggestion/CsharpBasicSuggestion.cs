using Services.Helper;
using Services.Models;
using System.Collections.Generic;

namespace Services.BasicSuggestion
{
	public class CsharpBasicSuggestion
    {
        private static List<MonacoSuggestionDto> _list = null;

        public static List<MonacoSuggestionDto> GetBasicSuggestion()
        {
            if(!(_list == null))
            {
                return _list;
            }
            else
            {
                CreateBasicSuggestion();
                return _list;
            }
        }

        private static void CreateBasicSuggestion()
        {
            _list = new List<MonacoSuggestionDto>();
            _list.Add(
                new MonacoSuggestionDto
                {
                    Label = "Console",
                    Documentation = $"Represents the standard input, output, and error streams for console applications" +
                        $".This class cannot be inherited.",
                    Kind = CompletionItemKind.Class,
                    InsertText = "Console"
                });
        }
    }
}
