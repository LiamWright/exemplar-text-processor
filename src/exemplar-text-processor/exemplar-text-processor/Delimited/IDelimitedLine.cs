using System.Collections.Generic;

namespace exemplar_text_processor.Delimited
{
    public interface IDelimitedLine
    {
        int Number { get; }
        IReadOnlyList<IDelimitedField> Fields { get; }
    }
}