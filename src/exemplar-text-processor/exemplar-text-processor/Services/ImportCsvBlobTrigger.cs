using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using exemplar_text_processor.Settings;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using exemplar_text_processor.Delimited;

namespace exemplar_text_processor.Services
{
    public static class ImportCsvBlobTrigger
    {
        [FunctionName("ImportCsvBlobTrigger")]
        public static async Task Run(
            string name,
            ILogger log,
            [Inject] IOptions<CosmosDbSettings> settings)
        {
            name = "Default text course summaries 2019 - Sheet1.csv";
            try
            {
                using (var client = new DocumentClient(new Uri(settings.Value.EndpointUri), settings.Value.PrimaryKey))
                {
                    await ImportFileContentAsync(settings.Value, client, name);
                }
            }
            catch (Exception e)
            {
                log.LogError(e, e.StackTrace);
            }
        }


        internal static async Task ImportFileContentAsync(CosmosDbSettings settings, DocumentClient client, string fileName)
        {
            var headings = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                var lineNumber = 0;

                foreach (var line in DelimitedFileReader.ReadLines(reader, new DelimitedFileSettings(true)))
                {
                    lineNumber++;

                    if (lineNumber == 1)
                    {
                        headings = line.Fields.Select(f => CleanHeading(f.Value)).ToList();
                        continue;
                    }

                    var dict = new Dictionary<string, object>();

                    foreach (var field in line.Fields)
                    {
                        dict[headings[field.Number - 1]] = field.Value;
                    }

                    var doc = dict.ToExpandoObject();

                    //await client.CreateDocumentAsync(
                    //    UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, collectionId),
                    //    doc);
                }
            }
            
        }

        internal static string CleanHeading(string heading)
        {
            var rgx = new Regex("[^a-zA-Z0-9_]");
            var cleaned = rgx.Replace(heading, string.Empty);

            if (Regex.IsMatch(cleaned, @"^\d"))
            {
                return $"_{cleaned}";
            }

            return cleaned;
        }

        internal static ExpandoObject ToExpandoObject(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            foreach (var kvp in dictionary)
            {
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpandoObject();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    var itemList = new List<object>();

                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpandoObject();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }
    }
}
