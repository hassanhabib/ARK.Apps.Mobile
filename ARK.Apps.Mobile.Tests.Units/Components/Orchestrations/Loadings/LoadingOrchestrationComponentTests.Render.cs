// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Orchestrations.Loadings;
using ARK.Apps.Mobile.Models.Components.Orchestrations.Loadings;
using FluentAssertions;
using SharpStyles.Models;

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
                .ComponentStyle.Should().BeNull();

            initialLoadingOrchestrationComponent
                .Style.Should().BeNull();

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
            // given 
            string expectedCardComponentCssClass =
                "card-component";

            // when
            this.renderedLoadingOrchestrationComponent =
                RenderComponent<LoadingOrchestrationComponent>();

            // then
            this.renderedLoadingOrchestrationComponent
                .Instance.ComponentStyle.Should()
                    .NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.Style.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.CardDivision.Should().NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.CardDivision.CssClass.Should()
                    .Be(expectedCardComponentCssClass);

            this.renderedLoadingOrchestrationComponent
                .Instance.LoadingSpinnerComponent.Should()
                    .NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.LoadingDotsComponent.Should()
                    .NotBeNull();
        }

        [Fact]
        public void ShouldRenderComponentStyles()
        {
            // given
            var expectedStyles =
                new LoadingOrchestrationComponentStyles
                {
                    CardDivision = new SharpStyle
                    {
                        TextAlign = "center",
                        Display = "flex",
                        JustifyContent = "center",
                        AlignItems = "center",
                        Border = "none",
                        Gap = "24px"
                    }
                };

            // when
            this.renderedLoadingOrchestrationComponent =
                RenderComponent<LoadingOrchestrationComponent>();

            // then
            this.renderedLoadingOrchestrationComponent
                .Instance.ComponentStyle.Should()
                    .NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.Style.Should()
                    .NotBeNull();

            this.renderedLoadingOrchestrationComponent
                .Instance.Style.Should()
                    .BeEquivalentTo(expectedStyles);
        }
    }
}
