// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners;
using ARK.Apps.Mobile.Models.Components.Orchestrations.Loadings;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Components.Orchestrations.Loadings
{
    public partial class LoadingOrchestrationComponent : ComponentBase
    {
        public StyleBase ComponentStyles { get; set; }
        public LoadingOrchestrationComponentStyles Styles { get; set; }
        public DivisionBase CardDivision { get; set; }
        public LoadingDotsComponent LoadingDotsComponent { get; set; }
        public LoadingSpinnerComponent LoadingSpinnerComponent { get; set; }
    }
}
