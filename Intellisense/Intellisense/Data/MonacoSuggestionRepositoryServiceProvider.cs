using Intellisense.Data.Interface;
using System;

namespace Intellisense.Data
{
    public class MonacoSuggestionRepositoryServiceProvider : ISuggestionServiceProvider
    {
        public IMonacoSuggestionRepository GetService(SuggestionLanguage.Languages language)
        {
            switch (language)
            {
                case (SuggestionLanguage.Languages.Csharp):
                    return new CsharpMonacoSuggestionRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}