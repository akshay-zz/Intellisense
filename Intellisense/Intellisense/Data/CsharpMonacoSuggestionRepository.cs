using DotNetFiddle.IntelligentCompletion;
using Intellisense.Data.Abstract;
using Intellisense.Data.BasicSuggestion;
using Intellisense.Dtos;
using Intellisense.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intellisense.Data
{
    public class CsharpMonacoSuggestionRepository: MonacoSuggestion
    {
        private List<AutoCompleteItem> _AutoCompleteItems;
        private List<MonacoSuggestionDto> _MonacoSuggestionDtos = new List<MonacoSuggestionDto>();        
        private string _RawCode = string.Empty;

        public CsharpMonacoSuggestionRepository()
        {
        }

        private void MapAutoCompleteToMonacoSuggestion()
        {
            foreach (AutoCompleteItem autoCompleteItem in _AutoCompleteItems)
			{
				_MonacoSuggestionDtos.Add(GetMonacoSuggestion(autoCompleteItem));
			}
		}

		private MonacoSuggestionDto GetMonacoSuggestion(AutoCompleteItem autoCompleteItem)
		{
			return new MonacoSuggestionDto()
			{
				Label = GetLabelWithDescription(autoCompleteItem),
				Kind = GetSuggestionKindByItemType(autoCompleteItem.ItemType),
				Documentation = autoCompleteItem.Description,
				InsertText = GetInsertText(autoCompleteItem)
			};
		}

		private string GetLabelWithDescription(AutoCompleteItem autoCompleteItem)
        {
            if (autoCompleteItem.ItemType == AutoCompleteItemType.Method)
            {
                if (autoCompleteItem.Params != null && autoCompleteItem.Params.Length > 0)
                {
                    List<string> functionParams = new List<string>();
                    var i = 1;
                    foreach (var param in autoCompleteItem.Params)
                    {
                        functionParams.Add(Handle.ToString(param.Type) + " param" + i++);
                    }

                    return $"{autoCompleteItem.Name}({String.Join(", ", functionParams)})";
                }
                return $"{autoCompleteItem.Name}()";
            }

            return autoCompleteItem.Name;
        }

        private string GetInsertText(AutoCompleteItem autoCompleteItem)
        {
            if (String.IsNullOrEmpty(autoCompleteItem.Description) &&
                    autoCompleteItem.ItemType == AutoCompleteItemType.Method
                    && autoCompleteItem.Params != null && autoCompleteItem.Params.Length > 0
            )
            {
                List<string> functionParams = new List<string>();
                var i = 1;

                foreach (var param in autoCompleteItem.Params)
                {
                    functionParams.Add(Handle.ToString("param" + i++));
                }

                return $"{autoCompleteItem.Name}({String.Join(", ", functionParams)})";
            }
            return autoCompleteItem.Name;
        }

        private string GetSuggestionKindByItemType(AutoCompleteItemType itemType)
        {
            switch (itemType)
            {
                case AutoCompleteItemType.Variable:
                    return CompletionItemKind.Variable;
                case AutoCompleteItemType.Property:
                    return CompletionItemKind.Property;
                case AutoCompleteItemType.Method:
                    return CompletionItemKind.Method;
                case AutoCompleteItemType.Class:
                    return CompletionItemKind.Class;
                case AutoCompleteItemType.Namespace:
                    return CompletionItemKind.Keyword;
                default:
                    throw new NotImplementedException(itemType.ToString() + " is not implemented");
            }
        }

        /// <summary>
        /// Return list of suggestion for monaco editor
        /// </summary>
        /// <returns>string</returns>
        public override async Task<string> GetMonacoSuggestion(CodeForSuggestionDto code)
            => await Task.Run(()
            =>
            {
                _RawCode = code.RawCode ?? throw new ArgumentNullException("Raw code cannot be null.");
                var service = new CSharpLanguageService();
                _AutoCompleteItems = service.GetAutoCompleteItems(_RawCode, code.Pos);
                MapAutoCompleteToMonacoSuggestion();
                return CreateSuggestionString(_MonacoSuggestionDtos);
            });

        public override async Task<string> GetBasicSuggestion()
           => await Task.Run(()
           =>
           {
               return CreateSuggestionString(CsharpBasicSuggestion.GetBasicSuggestion());
           });
    }
}
