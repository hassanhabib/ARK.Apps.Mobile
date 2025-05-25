// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARK.Apps.Mobile.Brokers.Arks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Models.Arks;
using ARK.Apps.Mobile.Services.Foundations;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace ARK.Apps.Mobile.Tests.Units.Services.Foundations
{
    public partial class ArkServiceTests
    {
        private readonly Mock<IArkApiBroker> arkApiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IArkService arkService;

        public ArkServiceTests()
        {
            this.arkApiBrokerMock =
                new Mock<IArkApiBroker>();

            this.loggingBrokerMock =
                new Mock<ILoggingBroker>();

            this.arkService = new ArkService(
                arkApiBroker: this.arkApiBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private List<Ark> CreateRandomArks() =>
            CreateArkFiller().Create(count: GetRandomNumber()).ToList();

        private int GetRandomNumber() =>
           new IntRange(min: 2, max: 10).GetValue();

        private Filler<Ark> CreateArkFiller()
        {
            var filler = new Filler<Ark>();

            filler.Setup()
                .OnType<DateTimeOffset>().IgnoreIt();

            return filler;
        }
    }
}
