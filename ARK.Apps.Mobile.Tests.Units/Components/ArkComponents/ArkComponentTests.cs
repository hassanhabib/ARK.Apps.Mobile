// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Syncfusion.Blazor;

namespace ARK.Apps.Mobile.Tests.Units.Components.ArkComponents
{
    public partial class ArkComponentTests : TestContext
    {
        private readonly Mock<IArkViewService> arkViewServiceMock;
        private IRenderedComponent<ArkComponent> renderedArkComponent;

        public ArkComponentTests()
        {
            this.arkViewServiceMock =
                new Mock<IArkViewService>();

            this.Services.AddTransient(service =>
                this.arkViewServiceMock.Object);

            this.Services.AddSyncfusionBlazor();
        }
    }
}
