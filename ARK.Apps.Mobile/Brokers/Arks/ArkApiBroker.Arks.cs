// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;

namespace ARK.Apps.Mobile.Brokers.Arks
{
    internal partial class ArkApiBroker
    {
        const string ArksApiBaseUrl = "api/arks";

        public async ValueTask<List<Ark>> GetAllArksAsync() =>
            await this.GetAsync<List<Ark>>(ArksApiBaseUrl);
    }
}
