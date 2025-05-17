// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Bases
{
    public partial class CarouselItemBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
