using BackUpApp.CLI;
using BackUpApp.Interfaces;
using BackUpApp.Interfaces.Repositories;
using BackUpApp.Repositories;
using BackUpApp.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BackUpApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var serviceCollection = new ServiceCollection();


            serviceCollection.AddSingleton<IGitHubService, GitHubService>();
            serviceCollection.AddSingleton<IGitHubRepository, GitHubRepository>();

            serviceCollection.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddSingleton<App>();

            var serviceProvider = serviceCollection.BuildServiceProvider(true);

            FlurlHttp.Configure(settings =>
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                    ContractResolver = new DefaultContractResolver()
                };
                settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
                settings.Timeout = TimeSpan.FromMilliseconds(5000);
            });

            var app = serviceProvider.GetService<App>();

            if (app != null)
            {
                app.Start();
            }
        }
    }
}
