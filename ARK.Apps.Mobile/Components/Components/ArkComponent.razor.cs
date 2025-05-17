// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Components
{
    public partial class ArkComponent : ComponentBase
    {
        [Inject]
        public IArkViewService ArkViewService { get; set; }

        public CarouselBase Carousel { get; set; }
    }
}
