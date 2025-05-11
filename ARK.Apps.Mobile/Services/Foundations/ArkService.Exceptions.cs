// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;
using ARK.Apps.Mobile.Models.Arks.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;
using Xeptions;

namespace ARK.Apps.Mobile.Services.Foundations
{
    internal partial class ArkService : IArkService
    {
        private delegate ValueTask<List<Ark>> ReturningArksFunction();

        private async ValueTask<List<Ark>> TryCatch(ReturningArksFunction returningArksFunction)
        {
            try
            {
                return await returningArksFunction();
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedArkConfigurationException =
                    new FailedArkConfigurationException(
                        message: "Failed ark configuration error occurred, contact support.",
                        innerException: httpResponseUrlNotFoundException);

                throw await CreateAndLogCriticalDependencyExceptionAsync(
                    failedArkConfigurationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedArkDependencyException =
                    new FailedArkDependencyException(
                        message: "Failed ark dependency error occurred, contact support.",
                        innerException: httpResponseException);

                throw await CreateAndLogDependencyExceptionAsync(
                    failedArkDependencyException);
            }
            catch (Exception exception)
            {
                var failedArkServiceException =
                    new FailedArkServiceException(
                        message: "Failed ark service error occurred, contact support.",
                        innerException: exception);

                throw await CreateAndLogServiceExceptionAsync(
                    failedArkServiceException);
            }
        }

        private async ValueTask<ArkDependencyException> CreateAndLogCriticalDependencyExceptionAsync(
            Xeption exception)
        {
            var arkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occurred, contact support.",
                    innerException: exception);

            await this.loggingBroker.LogCriticalAsync(arkDependencyException);

            return arkDependencyException;
        }

        private async ValueTask<ArkDependencyException> CreateAndLogDependencyExceptionAsync(
           Xeption exception)
        {
            var arkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occurred, contact support.",
                    innerException: exception);

            await this.loggingBroker.LogErrorAsync(arkDependencyException);

            return arkDependencyException;
        }

        private async ValueTask<ArkServiceException> CreateAndLogServiceExceptionAsync(
          Xeption exception)
        {
            var arkServiceException =
                new ArkServiceException(
                    message: "Ark service error occurred, contact support.",
                    innerException: exception);

            await this.loggingBroker.LogErrorAsync(arkServiceException);

            return arkServiceException;
        }
    }
}
