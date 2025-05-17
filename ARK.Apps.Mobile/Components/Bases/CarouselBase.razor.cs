using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Bases
{
    public partial class CarouselBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
