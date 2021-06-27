using Services.Models;
using System.Threading.Tasks;

namespace Services.Interface
{
	public interface IMonacoSuggestionRepository
    {
        Task<string> GetMonacoSuggestion(CodeForSuggestionDto code);
        Task<string> GetBasicSuggestion();
    }
}
