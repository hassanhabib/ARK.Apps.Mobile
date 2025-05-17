// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components;
using Bunit;
using FluentAssertions;

namespace ARK.Apps.Mobile.Tests.Units.Components.ArkComponents
{
    public partial class ArkComponentTests : TestContext
    {
        [Fact]
        public void ShouldRenderDefaultValues()
        {
            // given . when 
            var defaultArkComponent = new ArkComponent();

            // then
            defaultArkComponent.ArkViewService.Should().BeNull();
            defaultArkComponent.Carousel.Should().BeNull();
            this.arkViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
