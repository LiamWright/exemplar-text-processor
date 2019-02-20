using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Process.Course.Text.Delimited;
using Process.Course.Text.Interfaces;
using Process.Course.Text.Services;
using Process.Course.Text.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Process_Course_Text
{

    public class Program
    {
        public static ILoggerFactory LoggerFactory;
        public static IConfigurationRoot Configuration;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            Console.WriteLine("Environment: {0}", environment);

            var services = new ServiceCollection();

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            if (environment == "Development")
            {

                builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
                        optional: true
                    );
            }
            else
            {
                builder
                    .AddJsonFile($"appsettings.{environment}.json", optional: false);
            }
            Configuration = builder.Build();
            var serviceProvider = services.BuildServiceProvider();

           

        }
    }
    

    
    //public class ImportCsvBlobTrigger
    //{
    //    private readonly ICosmosDbHelper CosmosDbHelper;
    //    private readonly ICosmosDbSettings Settings;

    //    public ImportCsvBlobTrigger(
    //        ICosmosDbHelper cosmosDbHelper,
    //        IOptions<CosmosDbSettings> settings)
    //    {
            
    //        CosmosDbHelper = cosmosDbHelper;
    //    }
    //    public static async Task ImportAsync()
    //    {
    //        string name = "Default text course summaries 2019 - Sheet1.csv";
    //        try
    //        {
    //            using (var client = new DocumentClient(new Uri(Settings.Value.EndpointUri), settings.Value.PrimaryKey))
    //            {
    //                await ImportFileContentAsync(settings.Value, client, name);
    //            }
    //        }
    //        catch (Exception e)
    //        {
                
    //        }
    //    }


    //    internal static async Task ImportFileContentAsync(CosmosDbSettings settings, DocumentClient client, string fileName)
    //    {
    //        var headings = new List<string>();

    //        using (var reader = new StreamReader(fileName))
    //        {
    //            var lineNumber = 0;

    //            foreach (var line in DelimitedFileReader.ReadLines(reader, new DelimitedFileSettings(true)))
    //            {
    //                lineNumber++;

    //                if (lineNumber == 1)
    //                {
    //                    headings = line.Fields.Select(f => CleanHeading(f.Value)).ToList();
    //                    continue;
    //                }

    //                var dict = new Dictionary<string, object>();

    //                foreach (var field in line.Fields)
    //                {
    //                    dict[headings[field.Number - 1]] = field.Value;
    //                }

    //                var doc = dict.ToExpandoObject();

    //                //await client.CreateDocumentAsync(
    //                //    UriFactory.CreateDocumentCollectionUri(settings.DatabaseId, collectionId),
    //                //    doc);
    //            }
    //        }

    //    }

    //    internal static string CleanHeading(string heading)
    //    {
    //        var rgx = new Regex("[^a-zA-Z0-9_]");
    //        var cleaned = rgx.Replace(heading, string.Empty);

    //        if (Regex.IsMatch(cleaned, @"^\d"))
    //        {
    //            return $"_{cleaned}";
    //        }

    //        return cleaned;
    //    }

    //    internal static ExpandoObject ToExpandoObject(this IDictionary<string, object> dictionary)
    //    {
    //        var expando = new ExpandoObject();
    //        var expandoDic = (IDictionary<string, object>)expando;

    //        foreach (var kvp in dictionary)
    //        {
    //            if (kvp.Value is IDictionary<string, object>)
    //            {
    //                var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpandoObject();
    //                expandoDic.Add(kvp.Key, expandoValue);
    //            }
    //            else if (kvp.Value is ICollection)
    //            {
    //                var itemList = new List<object>();

    //                foreach (var item in (ICollection)kvp.Value)
    //                {
    //                    if (item is IDictionary<string, object>)
    //                    {
    //                        var expandoItem = ((IDictionary<string, object>)item).ToExpandoObject();
    //                        itemList.Add(expandoItem);
    //                    }
    //                    else
    //                    {
    //                        itemList.Add(item);
    //                    }
    //                }

    //                expandoDic.Add(kvp.Key, itemList);
    //            }
    //            else
    //            {
    //                expandoDic.Add(kvp);
    //            }
    //        }

    //        return expando;
    //    }
    //}
}


