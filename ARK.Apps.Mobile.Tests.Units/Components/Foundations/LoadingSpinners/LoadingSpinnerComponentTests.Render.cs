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

        [Fact]
        public void ShouldRenderLoadingSpinnerComponent()
        {
            // given
            string expectedDivisionCssClass = "rotated-box";
            string expectedSpinnerCssClass = "spinner";
            bool expectedIsVisibleFlag = true;
            string expectedSpinnerSize = "32";

            // when
            this.renderedLoadingSpinnerComponent =
                RenderComponent<LoadingSpinnerComponent>();

            // then
            this.renderedLoadingSpinnerComponent
                .Instance.Divison.Should().NotBeNull();

            this.renderedLoadingSpinnerComponent
                .Instance.Divison.CssClass.Should()
                    .Be(expectedDivisionCssClass);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.Should().NotBeNull();

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.CssClass.Should()
                    .Be(expectedSpinnerCssClass);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.IsVisible.Should()
                    .Be(expectedIsVisibleFlag);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.Size.Should()
                    .Be(expectedSpinnerSize);
        }
    }
}
