// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Components.Orchestrations.Loadings;
using Bunit;
using Syncfusion.Blazor;

namespace ARK.Apps.Mobile.Tests.Units.Components.Orchestrations.Loadings
{
    public partial class LoadingOrchestrationComponentTests : TestContext
    {
        private IRenderedComponent<LoadingOrchestrationComponent>
            renderedLoadingOrchestrationComponent;

        public LoadingOrchestrationComponentTests() =>
            this.Services.AddSyncfusionBlazor();
    }
}
