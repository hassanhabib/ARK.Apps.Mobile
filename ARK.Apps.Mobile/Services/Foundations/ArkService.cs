// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Brokers.Arks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Models.Arks;

namespace ARK.Apps.Mobile.Services.Foundations
{
    internal class ArkService : IArkService
    {
        private readonly IArkApiBroker arkApiBroker;
        private readonly ILoggingBroker loggingBroker;

        public ArkService(
            IArkApiBroker arkApiBroker,
            ILoggingBroker loggingBroker)
        {
            this.arkApiBroker = arkApiBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<List<Ark>> RetrieveAllArksAsync() =>
            await this.arkApiBroker.GetAllArksAsync();
    }
}
