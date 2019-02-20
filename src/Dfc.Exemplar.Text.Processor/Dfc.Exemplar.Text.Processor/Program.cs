using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Dfc.Exemplar.Text.Processor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.development.json");

            var configuration = builder.Build();

        }
    }
}
