﻿using exemplar_text_processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace exemplar_text_processor.Settings
{
    public class CosmosDbSettings : ICosmosDbSettings
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseId { get; set; }
        public string CourseTextCollectionId { get; set; }
    }
}