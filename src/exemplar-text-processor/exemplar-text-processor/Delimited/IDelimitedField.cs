﻿namespace exemplar_text_processor.Delimited
{
    public interface IDelimitedField
    {
        int Number { get; }
        string Value { get; }
        bool IsDoubleQuoted { get; }
    }
}