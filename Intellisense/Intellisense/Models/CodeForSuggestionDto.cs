using System;
using System.ComponentModel.DataAnnotations;

namespace Intellisense.Dtos
{
    public class CodeForSuggestionDto
    {
        [Required(AllowEmptyStrings = false)]
        public string RawCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Language { get; set; }

        [Range(1, 1000)]
        public int? Pos { get; set; }
    }

    public class LanguageForSuggestion
    {
        [Required(AllowEmptyStrings = false)]
        public string Language { get; set; }
    }
}
