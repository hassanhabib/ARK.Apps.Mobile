// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Bases
{
    public partial class ParagraphBase
    {
        [Parameter]
        public string CssClass { get; set; }

        [Parameter]
        public string Text { get; set; }
    }
}
