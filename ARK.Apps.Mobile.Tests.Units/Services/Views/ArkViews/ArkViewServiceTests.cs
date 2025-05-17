// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Services.Foundations;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Moq;
using Tynamix.ObjectFiller;

namespace ARK.Apps.Mobile.Tests.Units.Services.Views.ArkViews
{
    public partial class ArkViewServiceTests
    {
        private readonly Mock<IArkService> arkServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IArkViewService arkViewService;

        public ArkViewServiceTests()
        {
            this.arkServiceMock =
                new Mock<IArkService>();

            this.loggingBrokerMock =
                new Mock<ILoggingBroker>();

            this.arkViewService =
                new ArkViewService(
                    arkService: this.arkServiceMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static List<dynamic> CreateArkPropertiesCollection()
        {
            int count = GetRandomNumber();

            return Enumerable.Range(0, count).Select(_ =>
            {
                return new
                {
                    Id = Guid.NewGuid(),
                    Date = GetRandomDate(),
                    Act = GetRandomString()
                };
            }).ToList<dynamic>();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();
    }
}
