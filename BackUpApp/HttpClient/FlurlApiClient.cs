using Flurl.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackUpApp.HttpClient
{
    public static class FlurlApiClient
    {
        public static async Task<TResponse> SendRequestAsync<TRequest, TResponse>(IFlurlClient client, string path, HttpMethod httpMethod, TRequest requestBody)
        {
            IFlurlResponse response;

            if (requestBody is not null)
                response = await client.Request(path).AllowAnyHttpStatus().SendJsonAsync(httpMethod, requestBody);
            else
                response = await client.Request(path).AllowAnyHttpStatus().SendAsync(httpMethod);

            if (response.StatusCode < 300)
            {
                return await response.GetJsonAsync<TResponse>();
            }

            throw new Exception($"Exception: {response.StatusCode}");
        }
    }
}
