// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingSpinners;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners
{
    public partial class LoadingSpinnerComponent : ComponentBase
    {
        public DivisionBase Divison { get; set; }
        public SpinnerBase Spinner { get; set; }
        public LoadingSpinnerComponentStyles Styles { get; set; }
        public StyleBase ComponentStyle { get; set; }
    }
}
