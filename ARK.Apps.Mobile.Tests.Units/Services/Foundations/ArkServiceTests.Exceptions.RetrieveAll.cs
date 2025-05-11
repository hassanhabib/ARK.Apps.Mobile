// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;
using ARK.Apps.Mobile.Models.Arks.Exceptions;
using FluentAssertions;
using Moq;
using RESTFulSense.WebAssembly.Exceptions;

namespace ARK.Apps.Mobile.Tests.Units.Services.Foundations
{
    public partial class ArkServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionIfCriticalErrorOccurrsAndLogItAsync()
        {
            // given
            var randomHttpResponseMessage =
                new HttpResponseMessage();

            string someResponseMessage =
                GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException(
                    responseMessage: randomHttpResponseMessage,
                    message: someResponseMessage);

            var failedArkConfigurationException =
                new FailedArkConfigurationException(
                    message: "Failed ark configuration error occurred, contact support.",
                    innerException: httpResponseUrlNotFoundException);

            var expectedArkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occurred, contact support.",
                    innerException: failedArkConfigurationException);

            this.arkApiBrokerMock.Setup(broker =>
                broker.GetAllArksAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<List<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkDependencyException actualArkDependencyException =
                await Assert.ThrowsAsync<ArkDependencyException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkDependencyException.Should().BeEquivalentTo(
                expectedArkDependencyException);

            this.arkApiBrokerMock.Verify(broker =>
                broker.GetAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCriticalAsync(It.Is(
                    SameExceptionAs(expectedArkDependencyException))),
                        Times.Once);

            this.arkApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionIfDependencyErrorOccurrsAndLogItAsync()
        {
            // given
            var randomHttpResponseMessage =
                new HttpResponseMessage();

            string someResponseMessage =
                GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseException(
                    httpResponseMessage: randomHttpResponseMessage,
                    message: someResponseMessage);

            var failedArkDependencyException =
                new FailedArkDependencyException(
                    message: "Failed ark dependency error occurred, contact support.",
                    innerException: httpResponseUrlNotFoundException);

            var expectedArkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occurred, contact support.",
                    innerException: failedArkDependencyException);

            this.arkApiBrokerMock.Setup(broker =>
                broker.GetAllArksAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<List<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkDependencyException actualArkDependencyException =
                await Assert.ThrowsAsync<ArkDependencyException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkDependencyException.Should().BeEquivalentTo(
                expectedArkDependencyException);

            this.arkApiBrokerMock.Verify(broker =>
                broker.GetAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogErrorAsync(It.Is(
                    SameExceptionAs(expectedArkDependencyException))),
                        Times.Once);

            this.arkApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionIfServiceErrorOccurrsAndLogItAsync()
        {
            // given
            var serviceException = new Exception();

            var failedArkServiceException =
                new FailedArkServiceException(
                    message: "Failed ark service error occurred, contact support.",
                    innerException: serviceException);

            var expectedArkServiceException =
                new ArkServiceException(
                    message: "Ark service error occurred, contact support.",
                    innerException: failedArkServiceException);

            this.arkApiBrokerMock.Setup(broker =>
                broker.GetAllArksAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkServiceException actualArkServiceException =
                await Assert.ThrowsAsync<ArkServiceException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkServiceException.Should().BeEquivalentTo(
                expectedArkServiceException);

            this.arkApiBrokerMock.Verify(broker =>
                broker.GetAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogErrorAsync(It.Is(
                    SameExceptionAs(expectedArkServiceException))),
                        Times.Once);

            this.arkApiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
