namespace exemplar_text_processor.Delimited
{
    public interface IDelimitedFileSettings
    {
        char DelimitingCharacter { get; }
        bool IsFirstRowHeaders { get; }
    }
}