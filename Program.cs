using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using ImageClassification.ModelScorer;
using ImageClassification.ModelScorer;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace BlazorApp_ml.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Logging.AddProvider(new CustomLoggingProvider());
	        CreateHostBuilder(args).Build().Run(); 
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
