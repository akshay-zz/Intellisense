using Services.Helper;

namespace Services.Interface
{
	public interface ISuggestionServiceProvider
    {
        IMonacoSuggestionRepository GetService(SuggestionLanguage.Languages language);
    }
}
