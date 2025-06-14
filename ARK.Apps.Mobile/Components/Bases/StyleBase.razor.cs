// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using SharpStyles.Models;

namespace ARK.Apps.Mobile.Components.Bases
{
    public partial class StyleBase
    {
        [Parameter]
        public SharpStyle Styles { get; set; }
    }
}
