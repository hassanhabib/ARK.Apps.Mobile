// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Components.Components;
using ARK.Apps.Mobile.Models.Views.ArkViews;
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
            // given . when 
            var defaultArkComponent = new ArkComponent();

            // then
            defaultArkComponent.ArkViewService.Should().BeNull();
            defaultArkComponent.Carousel.Should().BeNull();
            this.arkViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRenderArkViewsAsync()
        {
            // given
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
            this.renderedArkComponent.Instance.Carousel
                .Should().NotBeNull();

            IReadOnlyList<IRenderedComponent<CarouselItemBase>> 
                renderedCarouselComponentItems =
                    this.renderedArkComponent
                        .FindComponents<CarouselItemBase>();

            foreach(ArkView arkView in retrievedArkViews)
            {
                bool containsAct = renderedCarouselComponentItems
                    .Any(item => item.Markup.Contains(arkView.Act));

                containsAct.Should().BeTrue();
            }

            this.arkViewServiceMock.Verify(service =>
                service.RetrieveAllArkViewsAsync(),
                    Times.Once);

            this.arkViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
