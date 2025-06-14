// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners;
using Bunit;
using FluentAssertions;

namespace ARK.Apps.Mobile.Tests.Units.Components.Foundations.LoadingSpinners
{
    public partial class LoadingSpinnerComponentTests : TestContext
    {
        [Fact]
        public void ShouldRenderDefaults()
        {
            // given . when
            var initialLoadingSpinnerComponent =
                new LoadingSpinnerComponent();

            // then
            initialLoadingSpinnerComponent.Spinner
                .Should().BeNull();

            initialLoadingSpinnerComponent.ComponentStyle
                .Should().BeNull();

            initialLoadingSpinnerComponent.Divison
                .Should().BeNull();

            initialLoadingSpinnerComponent.Styles
                .Should().BeNull();
        }
    }
}
