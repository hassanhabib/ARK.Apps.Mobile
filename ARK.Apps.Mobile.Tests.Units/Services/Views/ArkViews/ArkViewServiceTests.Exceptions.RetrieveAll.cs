// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks.Exceptions;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Models.Views.ArkViews.Exceptions;
using FluentAssertions;
using Moq;
using Xeptions;

namespace ARK.Apps.Mobile.Tests.Units.Services.Views.ArkViews
{
    public partial class ArkViewServiceTests
    {
        [Theory]
        [MemberData(nameof(ArkDependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveAllIfDependnecyErrorOccurredAndLogItAsync(
            Xeption arkDependencyException)
        {
            // given
            var failedArkViewDependencyException =
                new FailedArkViewDependencyException(
                    message: "Failed ark view dependency error occurred, contact support.",
                    innerException: (Xeption) arkDependencyException.InnerException);

            var expectedArkViewDependencyException =
                new ArkViewDependencyException(
                    message: "Ark view dependency error occurred, contact support.",
                    innerException: failedArkViewDependencyException);

            this.arkServiceMock.Setup(service =>
                service.RetrieveAllArksAsync())
                    .ThrowsAsync(arkDependencyException);

            // when
            ValueTask<List<ArkView>> retrieveAllArkViewsTask =
                this.arkViewService.RetrieveAllArkViewsAsync();

            ArkViewDependencyException actualArkViewDependencyException =
                await Assert.ThrowsAsync<ArkViewDependencyException>(
                    testCode: retrieveAllArkViewsTask.AsTask);

            // then
            actualArkViewDependencyException.Should().BeEquivalentTo(
                expectedArkViewDependencyException);

            this.arkServiceMock.Verify(service =>
                service.RetrieveAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogErrorAsync(It.Is(
                    SameExceptionAs(expectedArkViewDependencyException))),
                        Times.Once);

            this.arkServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
