// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots;
using FluentAssertions;

namespace ARK.Apps.Mobile.Tests.Units.Components.Foundations.LoadingDots
{
    public partial class LoadingDotsComponentTests
    {
        [Fact]
        public void ShouldInitializeDefaultValues()
        {
            // given . when
            var initialLoadingDotsComponent =
                new LoadingDotsComponent();

            // then
            initialLoadingDotsComponent
                .LargeHeader.Should().BeNull();

            initialLoadingDotsComponent
                .Paragraph.Should().BeNull();

            initialLoadingDotsComponent
                .DotsContainerDivision.Should()
                    .BeNull();

            initialLoadingDotsComponent
                .Dot0Division.Should().BeNull();

            initialLoadingDotsComponent
                .Dot1Division.Should().BeNull();

            initialLoadingDotsComponent
                .Dot2Division.Should().BeNull();
        }
    }
}
