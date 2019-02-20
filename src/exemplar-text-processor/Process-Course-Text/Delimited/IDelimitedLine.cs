using System.Collections.Generic;

namespace Process.Course.Text.Delimited
{
    public interface IDelimitedLine
    {
        int Number { get; }
        IReadOnlyList<IDelimitedField> Fields { get; }
    }
}