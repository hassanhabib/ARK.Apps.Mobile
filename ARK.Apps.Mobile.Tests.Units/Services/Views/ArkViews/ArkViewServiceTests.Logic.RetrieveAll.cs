// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using FluentAssertions;
using Moq;

namespace ARK.Apps.Mobile.Tests.Units.Services.Views.ArkViews
{
    public partial class ArkViewServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllArkViewsAsync()
        {
            // given
            List<dynamic> randomArkViewPropertyCollection =
                CreateArkPropertiesCollection();

            List<ArkView> expectedArkViews =
                randomArkViewPropertyCollection.Select(arkViewProperties =>
                {
                    return new ArkView
                    {
                        Id = arkViewProperties.Id,
                        Date = arkViewProperties.Date,
                        Act = arkViewProperties.Act
                    };
                }).ToList();

            List<Ark> retrievedArks =
                randomArkViewPropertyCollection.Select(arkViewProperties =>
                {
                    return new Ark
                    {
                        Id = arkViewProperties.Id,
                        Date = arkViewProperties.Date,
                        Act = arkViewProperties.Act
                    };
                }).ToList();

            this.arkServiceMock.Setup(service =>
                service.RetrieveAllArksAsync())
                    .ReturnsAsync(retrievedArks);

            // when
            List<ArkView> actualArkViews =
                await this.arkViewService.RetrieveAllArkViewsAsync();

            // then
            actualArkViews.Should().BeEquivalentTo(expectedArkViews);

            this.arkServiceMock.Verify(service =>
                service.RetrieveAllArksAsync(),
                    Times.Once);

            this.arkServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
