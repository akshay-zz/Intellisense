using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intellisense.Data.Interface
{
    public interface ISuggestionServiceProvider
    {
        IMonacoSuggestionRepository GetService(SuggestionLanguage.Languages language);
    }
}
