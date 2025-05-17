// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Services.Foundations;

namespace ARK.Apps.Mobile.Services.Views.ArkViews
{
    internal class ArkViewService : IArkViewService
    {
        private readonly IArkService arkService;
        private readonly ILoggingBroker loggingBroker;

        public ArkViewService(
            IArkService arkService,
            ILoggingBroker loggingBroker)
        {
            this.arkService = arkService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<ArkView>> RetrieveAllArkViewsAsync() =>
            throw new NotImplementedException();
    }
}
