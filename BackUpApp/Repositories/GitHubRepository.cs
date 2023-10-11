using BackUpApp.HttpClient;
using BackUpApp.Interfaces.Repositories;
using BackUpApp.Models.Dto;
using BackUpApp.Models.Dto.ListOfPrivateRepositories;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackUpApp.Repositories
{
    public class GitHubRepository : IGitHubRepository
    {
        private readonly IFlurlClient _client;

        public GitHubRepository(IFlurlClientFactory flurlClientFactory, IConfiguration configuration)
        {

            _client = flurlClientFactory.Get(configuration["ApiClient:GitHub:BaseUrl"]);

            _client.BaseUrl = configuration.GetSection("ApiClient:GitHub:BaseUrl").Value;

            _client.Headers.Clear();

            _client.Headers.Add("Accept", "application/vnd.github+json");
            _client.Headers.Add("X-GitHub-Api-Version", "2022-11-28");

            _client.Configure(settings => settings.Timeout = TimeSpan.FromSeconds(5));
            _client.WithTimeout(TimeSpan.FromSeconds(15));
        }

        public async Task<ListOfPrivateRepositoriesDto> GetListOfPrivateRepositories(ListOfPrivateRepositoriesParameters parameters)
        {
            _client.Headers.Add("Authorization", $"Bearer {parameters.AuthToken}");
            var path = "/user/repos?type=private";

            ListOfPrivateRepositoriesDto response;

            try
            {
                response = await FlurlApiClient.SendRequestAsync<ListOfPrivateRepositoriesParameters ,ListOfPrivateRepositoriesDto>(
               _client, path, HttpMethod.Get, null);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
