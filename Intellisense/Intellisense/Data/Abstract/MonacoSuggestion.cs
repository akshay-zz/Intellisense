using Intellisense.Data.Interface;
using Intellisense.Dtos;
using Intellisense.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intellisense.Data.Abstract
{
    public abstract class MonacoSuggestion : IMonacoSuggestionRepository
    {
		protected string CreateIndiviualSuggestionJSON(MonacoSuggestionDto suggestionDO) => $@"
        {{
            label:'""{Handle.ToString(suggestionDO.Label)}""',
            kind: {Handle.ToString(suggestionDO.Kind)},
            documentation: ""{Handle.ToString(suggestionDO.Documentation)}"",
            insertText: ""{Handle.ToString(suggestionDO.InsertText)}""
        }}";

		protected virtual string CreateSuggestionString(List<MonacoSuggestionDto> monacoSuggestionDtos)
        {
            var suggestionList = new List<string>();

            foreach (MonacoSuggestionDto suggestion in monacoSuggestionDtos)
            {
                suggestionList.Add(CreateIndiviualSuggestionJSON(suggestion));
            }
            return "[" + string.Join(", ", suggestionList.ToArray()) + "]";
        }

        public virtual Task<string> GetMonacoSuggestion(CodeForSuggestionDto code)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetBasicSuggestion()
        {
            throw new NotImplementedException();
        }
    }
}