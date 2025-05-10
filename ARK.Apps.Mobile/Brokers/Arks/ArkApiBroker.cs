// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RESTFulSense.WebAssembly.Clients;

namespace ARK.Apps.Mobile.Brokers.Arks
{
    internal partial class ArkApiBroker : IArkApiBroker
    {
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient restfulApiFactoryClient;
        private readonly IConfiguration configuration;

        public ArkApiBroker(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            
            this.restfulApiFactoryClient =
                GetRESTFulApiClient();
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.restfulApiFactoryClient.GetContentAsync<T>(relativeUrl);

        private IRESTFulApiFactoryClient GetRESTFulApiClient()
        {
            string apiBaseUrl =
                this.configuration.GetValue<string>("ArkApiBaseAddress");
            this.httpClient.BaseAddress = new Uri(apiBaseUrl);

            return new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}
