// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Models.Arks;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Services.Foundations;

namespace ARK.Apps.Mobile.Services.Views.ArkViews
{
    internal partial class ArkViewService
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
        TryCatch(async () =>
        {
            List<Ark> retrievedArks =
                await this.arkService.RetrieveAllArksAsync();

            return retrievedArks.Select(MapToArkView())
                .ToList();
        });

        private static Func<Ark, ArkView> MapToArkView()
        {
            return ark => new ArkView
            {
                Id = ark.Id,
                Date = ark.Date,
                Act = ark.Act
            };
        }
    }
}
