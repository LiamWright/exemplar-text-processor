using System;
using System.Collections.Generic;
using System.Text;

namespace exemplar_text_processor.Interfaces
{
    public interface ICosmosDbSettings
    {
        string EndpointUri { get; }
        string PrimaryKey { get; }
        string DatabaseId { get; }
        string CourseTextCollectionId { get; }
    }
}
