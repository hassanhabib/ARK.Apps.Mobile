// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using ARK.Apps.Mobile.Components.Components;
using ARK.Apps.Mobile.Models.Views.Components.ArkComponents;
using Bunit;
using FluentAssertions;
using Moq;
using Xeptions;

namespace ARK.Apps.Mobile.Tests.Units.Components.ArkComponents
{
    public partial class ArkComponentTests : TestContext
    {
        [Fact]
        public async Task ShouldRenderErrorIfRetrieveArksFailsAsync()
        {
            // given
            var someException = new Xeption();

            ArkComponentState expectedState =
                ArkComponentState.Error;

            string expectedErrorMessage =
                "We couldn't retrieve an act of kindness suggestion for you today." +
                " Please look within and find a kindness that fits you.";

            this.arkViewServiceMock.Setup(service =>
                service.RetrieveAllArkViewsAsync())
                    .ThrowsAsync(someException);

            // when
            this.renderedArkComponent =
                RenderComponent<ArkComponent>();

            // then
            this.renderedArkComponent.Instance.State
                .Should().Be(expectedState);
            
            this.renderedArkComponent.Instance.ErrorLabel
                .Should().NotBeNull();

            this.renderedArkComponent.Instance.ErrorLabel.Value
                .Should().Be(expectedErrorMessage);

            this.arkViewServiceMock.Verify(service =>
                service.RetrieveAllArkViewsAsync(),
                    Times.Once);

            this.arkViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
