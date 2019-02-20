namespace Process.Course.Text.Delimited
{
    public interface IDelimitedFileSettings
    {
        char DelimitingCharacter { get; }
        bool IsFirstRowHeaders { get; }
    }
}