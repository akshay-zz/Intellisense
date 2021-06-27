using Services.Helper;
using Services.Interface;
using System;

namespace Services.Implementation
{
	public class MonacoSuggestionRepositoryServiceProvider : ISuggestionServiceProvider
    {
        public IMonacoSuggestionRepository GetService(SuggestionLanguage.Languages language)
        {
            switch(language)
            {
                case (SuggestionLanguage.Languages.Csharp):
                    return new CsharpMonacoSuggestionRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
