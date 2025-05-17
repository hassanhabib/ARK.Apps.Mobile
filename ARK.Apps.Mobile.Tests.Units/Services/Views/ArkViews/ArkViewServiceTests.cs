// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Models.Arks.Exceptions;
using ARK.Apps.Mobile.Services.Foundations;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

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

        public static TheoryData<Xeption> ArkDependencyExceptions()
        {
            var someInnerException = new Xeption();
            string someMesasge = GetRandomString();

            return new TheoryData<Xeption>
            {
                new ArkDependencyException(someMesasge, someInnerException),
                new ArkServiceException(someMesasge, someInnerException)
            };
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);
    }
}
