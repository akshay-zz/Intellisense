using Intellisense.Dtos;
using System.Threading.Tasks;

namespace Intellisense.Data.Interface
{
    public interface IMonacoSuggestionRepository
    {
        Task<string> GetMonacoSuggestion(CodeForSuggestionDto code);
        Task<string> GetBasicSuggestion();
    }
}
