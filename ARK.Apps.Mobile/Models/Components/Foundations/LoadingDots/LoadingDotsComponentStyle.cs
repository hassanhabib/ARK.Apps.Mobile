// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using SharpStyles.Models;
using SharpStyles.Models.Attributes;

namespace ARK.Apps.Mobile.Models.Components.Foundations.LoadingDots
{
    public class LoadingDotsComponentStyle : SharpStyle
    {
        [CssClass(Selector = ".paragraph")]
        public SharpStyle Paragraph { get; set; }

        [CssClass(Selector = ".large-header")]
        public SharpStyle LargeHeader { get; set; }

        [CssClass(Selector = ".loading-dots-container")]
        public SharpStyle DotsContainerDivision { get; set; }

        [CssClass(Selector = ".dot")]
        public SharpStyle Dot { get; set; }

        [CssClass(Selector = ".dot-0")]
        public SharpStyle Dot0Division { get; set; }

        [CssClass(Selector = ".dot-1")]
        public SharpStyle Dot1Division { get; set; }

        [CssClass(Selector = ".dot-2")]
        public SharpStyle Dot2Division { get; set; }
    }
}
