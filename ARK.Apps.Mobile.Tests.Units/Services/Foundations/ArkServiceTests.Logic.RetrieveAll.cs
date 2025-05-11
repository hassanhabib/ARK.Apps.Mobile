// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace ARK.Apps.Mobile.Tests.Units.Services.Foundations
{
    public partial class ArkServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllArksAsync()
        {
            // given
            List<Ark> randomArks =
                CreateRandomArks();

            List<Ark> returnedArks = randomArks;

            List<Ark> expectedArks =
                returnedArks.DeepClone();

            this.arkApiBrokerMock.Setup(broker =>
                broker.GetAllArksAsync())
                    .ReturnsAsync(returnedArks);

            // when
            List<Ark> actualArks =
                await this.arkService.RetrieveAllArksAsync();

            // then
            actualArks.Should().BeEquivalentTo(expectedArks);

            this.arkApiBrokerMock.Verify(broker =>
                broker.GetAllArksAsync(),
                    Times.Once);

            this.arkApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
