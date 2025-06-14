// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using SharpStyles.Models;
using SharpStyles.Models.Attributes;

namespace ARK.Apps.Mobile.Models.Components.Foundations.LoadingSpinners
{
    public class LoadingSpinnerComponentStyles : SharpStyle
    {
        [CssClass]
        public SharpStyle RotatedBox { get; set; }

        [CssClass]
        public SharpStyle Spinner { get; set; }

        [CssClass(Selector = ".e-spinner-pane .e-spinner-inner .e-spin-bootstrap5")]
        public SharpStyle SpinnerStroke { get; set; }
    }
}
