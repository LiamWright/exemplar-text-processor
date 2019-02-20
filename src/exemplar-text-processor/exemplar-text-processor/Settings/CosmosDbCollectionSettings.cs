using exemplar_text_processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace exemplar_text_processor.Settings
{
    public class CosmosDbCollectionSettings : ICosmosDbCollectionSettings
    {
        public string CourseTextCollectionId { get; set; }
    }
}
