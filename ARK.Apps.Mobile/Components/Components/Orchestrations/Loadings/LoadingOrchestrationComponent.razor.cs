// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners;
using ARK.Apps.Mobile.Models.Components.Orchestrations.Loadings;
using Microsoft.AspNetCore.Components;
using SharpStyles.Models;

namespace ARK.Apps.Mobile.Components.Components.Orchestrations.Loadings
{
    public partial class LoadingOrchestrationComponent : ComponentBase
    {
        public StyleBase ComponentStyle { get; set; }
        public LoadingOrchestrationComponentStyles Style { get; set; }
        public DivisionBase CardDivision { get; set; }
        public LoadingSpinnerComponent LoadingSpinnerComponent { get; set; }
        public LoadingDotsComponent LoadingDotsComponent { get; set; }

        protected override void OnInitialized() =>
            this.Style = SetupStyles();

        private static LoadingOrchestrationComponentStyles SetupStyles()
        {
            return new LoadingOrchestrationComponentStyles
            {
                CardDivision = new SharpStyle
                {
                    TextAlign = "center",
                    Display = "flex",
                    FlexDirection = "column",
                    JustifyContent = "center",
                    AlignItems = "center",
                    Border = "none",
                    Gap = "24px"
                }
            };
        }
    }
}
