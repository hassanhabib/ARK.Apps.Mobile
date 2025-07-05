// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Orchestrations.Loadings;
using FluentAssertions;

namespace ARK.Apps.Mobile.Tests.Units.Components.Orchestrations.Loadings
{
    public partial class LoadingOrchestrationComponentTests
    {
        [Fact]
        public void ShouldRenderDefaults()
        {
            // given . when
            var initialLoadingOrchestrationComponent =
                new LoadingOrchestrationComponent();

            // then
            initialLoadingOrchestrationComponent
                .ComponentStyles.Should().BeNull();

            initialLoadingOrchestrationComponent
                .Styles.Should().BeNull();

            initialLoadingOrchestrationComponent
                .CardDivision.Should().BeNull();

            initialLoadingOrchestrationComponent
                .LoadingSpinnerComponent.Should().BeNull();

            initialLoadingOrchestrationComponent
                .LoadingDotsComponent.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponentOnInitialize()
        {
            // given . when
            this.renderedLoadingOrchestrationComponent =
                RenderComponent<LoadingOrchestrationComponent>();

            // then
            this.renderedLoadingOrchestrationComponent
                .Instance.ComponentStyles.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.Styles.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.CardDivision.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.LoadingSpinnerComponent.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.LoadingDotsComponent.Should().NotBeNull();
        }
    }
}
