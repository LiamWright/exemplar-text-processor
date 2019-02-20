namespace Process.Course.Text.Delimited
{
    public interface IDelimitedField
    {
        int Number { get; }
        string Value { get; }
        bool IsDoubleQuoted { get; }
    }
}