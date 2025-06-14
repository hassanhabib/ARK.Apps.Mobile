// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners;
using Bunit;
using Syncfusion.Blazor;

namespace ARK.Apps.Mobile.Tests.Units.Components.Foundations.LoadingSpinners
{
    public partial class LoadingSpinnerComponentTests : TestContext
    {
        private IRenderedComponent<LoadingSpinnerComponent> renderedLoadingSpinnerComponent;

        public LoadingSpinnerComponentTests() =>
            this.Services.AddSyncfusionBlazor();
    }
}
