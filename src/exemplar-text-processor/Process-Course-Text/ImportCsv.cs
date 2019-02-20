using Microsoft.Extensions.Options;
using Process.Course.Text.Helpers;
using Process.Course.Text.Interfaces;
using Process.Course.Text.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Process_Course_Text
{
    public class ImportCsv
    {
        private readonly ICosmosDbHelper CosmosDbHelper;
        private readonly ICosmosDbSettings Settings;

        public ImportCsv(
            CosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> settings)
        {
            CosmosDbHelper = cosmosDbHelper;
            Settings = settings.Value; 
        }
    }
}
