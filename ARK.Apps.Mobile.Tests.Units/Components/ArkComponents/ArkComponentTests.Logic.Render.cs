// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Components.Components;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Models.Views.Components.ArkComponents;
using Bunit;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace ARK.Apps.Mobile.Tests.Units.Components.ArkComponents
{
    public partial class ArkComponentTests : TestContext
    {
        [Fact]
        public void ShouldRenderDefaultValues()
        {
            // given
            ArkComponentState expectedState =
                ArkComponentState.Loading;

            // when
            var defaultArkComponent = new ArkComponent();

            // then
            defaultArkComponent.State.Should().Be(expectedState);
            defaultArkComponent.LoadingLabel.Should().BeNull();
            defaultArkComponent.ArkViewService.Should().BeNull();
            defaultArkComponent.Carousel.Should().BeNull();
            this.arkViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRenderLoadingUponRetrievingArksAsync()
        {
            // given
            List<ArkView> someArkViews =
                CreateRandomArkViews();

            string expectedLoadingMessage =
                "Loading ...";

            this.arkViewServiceMock.Setup(service =>
                service.RetrieveAllArkViewsAsync())
                    .ReturnsAsync(
                        value: someArkViews,
                        delay: TimeSpan.FromMilliseconds(1000));

            // when
            this.renderedArkComponent =
                RenderComponent<ArkComponent>();

            // then
            this.renderedArkComponent.Instance.LoadingLabel
                .Should().NotBeNull();

            this.renderedArkComponent.Instance.LoadingLabel
                .Value.Should().Be(expectedLoadingMessage);

            this.arkViewServiceMock.Verify(service =>
                service.RetrieveAllArkViewsAsync(),
                    Times.Once);

            this.arkViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRenderArkViewsAsync()
        {
            // given
            ArkComponentState expectedState =
                ArkComponentState.Content;

            List<ArkView> randomArkViews =
                CreateRandomArkViews();

            List<ArkView> retrievedArkViews =
                randomArkViews;

            this.arkViewServiceMock.Setup(service =>
                service.RetrieveAllArkViewsAsync())
                    .ReturnsAsync(retrievedArkViews);

            // when
            this.renderedArkComponent =
                RenderComponent<ArkComponent>();

            // then
            this.renderedArkComponent.Instance.State
                .Should().Be(expectedState);

            this.renderedArkComponent.Instance.LoadingLabel
                .Should().BeNull();

            this.renderedArkComponent.Instance.Carousel
                .Should().NotBeNull();

            IReadOnlyList<IRenderedComponent<CarouselItemBase>> 
                renderedCarouselComponentItems =
                    this.renderedArkComponent
                        .FindComponents<CarouselItemBase>();

            foreach(ArkView arkView in retrievedArkViews)
            {
                bool containsAct = renderedCarouselComponentItems
                    .Any(item => item.Instance.Value == arkView.Act);

                containsAct.Should().BeTrue();
            }

            this.arkViewServiceMock.Verify(service =>
                service.RetrieveAllArkViewsAsync(),
                    Times.Once);

            this.arkViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
