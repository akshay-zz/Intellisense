namespace Intellisense.Dtos
{
    public class MonacoSuggestionDto
    {
        public string Label { get; set; }
        public string Kind { get; set; }
        public string Documentation { get; set; }
        public string InsertText { get; set; }
    }
}
