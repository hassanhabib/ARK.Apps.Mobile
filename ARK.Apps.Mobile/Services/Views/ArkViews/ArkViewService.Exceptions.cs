// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks.Exceptions;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Models.Views.ArkViews.Exceptions;
using Xeptions;

namespace ARK.Apps.Mobile.Services.Views.ArkViews
{
    internal partial class ArkViewService : IArkViewService
    {
        private delegate ValueTask<List<ArkView>> ReturningArkViewsFunction();

        private async ValueTask<List<ArkView>> TryCatch(
            ReturningArkViewsFunction returningArkViewsFunction)
        {
            try
            {
                return await returningArkViewsFunction();
            }
            catch (ArkDependencyException arkDependencyException)
            {
                var failedArkViewDependencyException =
                    new FailedArkViewDependencyException(
                        message: "Failed ark view dependency error occurred, contact support.",
                        innerException: (Xeption)arkDependencyException.InnerException);

                throw await CreateAndLogArkViewDependencyExceptionAsync(
                    failedArkViewDependencyException);
            }
            catch (ArkServiceException arkServiceException)
            {
                var failedArkViewDependencyException =
                    new FailedArkViewDependencyException(
                        message: "Failed ark view dependency error occurred, contact support.",
                        innerException: (Xeption)arkServiceException.InnerException);

                throw await CreateAndLogArkViewDependencyExceptionAsync(failedArkViewDependencyException);
            }
            catch (Exception exception)
            {
                var failedArkViewServiceException =
                    new FailedArkViewServiceException(
                        message: "Failed ark view service error occurred, contact support.",
                        innerException: exception);

                throw await CreateAndLogArkViewServiceExceptionAsync(
                    failedArkViewServiceException);
            }
        }

        private async ValueTask<ArkViewDependencyException> CreateAndLogArkViewDependencyExceptionAsync(
            Xeption innerException)
        {
            var arkViewDependencyException =
                new ArkViewDependencyException(
                    message: "Ark view dependency error occurred, contact support.",
                    innerException: innerException);

            await this.loggingBroker.LogErrorAsync(arkViewDependencyException);

            return arkViewDependencyException;
        }

        private async ValueTask<ArkViewServiceException> CreateAndLogArkViewServiceExceptionAsync(
         Xeption innerException)
        {
            var arkViewServiceException =
                new ArkViewServiceException(
                    message: "Ark view service error occurred, contact support.",
                    innerException: innerException);

            await this.loggingBroker.LogErrorAsync(arkViewServiceException);

            return arkViewServiceException;
        }
    }
}
