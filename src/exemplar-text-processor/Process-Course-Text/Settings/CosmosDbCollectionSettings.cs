using Process.Course.Text.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Process.Course.Text.Settings
{
    public class CosmosDbCollectionSettings : ICosmosDbCollectionSettings
    {
        public string CourseTextCollectionId { get; set; }
    }
}
