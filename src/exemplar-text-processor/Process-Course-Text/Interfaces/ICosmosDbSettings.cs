using System;
using System.Collections.Generic;
using System.Text;

namespace Process.Course.Text.Interfaces
{
    public interface ICosmosDbSettings
    {
        string EndpointUri { get; }
        string PrimaryKey { get; }
        string DatabaseId { get; }
        string CourseTextCollectionId { get; }
    }
}
