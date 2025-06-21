// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingDots;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots
{
    public partial class LoadingDotsComponent : ComponentBase
    {
        public StyleBase ComponentStyle { get; set; }
        public LoadingDotsComponentStyle Style { get; set; }
        public LargeHeaderBase LargeHeader { get; set; }
        public ParagraphBase Paragraph { get; set; }
        public DivisionBase DotsContainerDivision { get; set; }
        public DivisionBase Dot0Division { get; set; }
        public DivisionBase Dot1Division { get; set; }
        public DivisionBase Dot2Division { get; set; }

        protected override void OnInitialized()
        {
            this.Style = new LoadingDotsComponentStyle();
        }
    }
}
