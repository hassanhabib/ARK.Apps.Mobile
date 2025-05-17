// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Views.ArkViews;

namespace ARK.Apps.Mobile.Services.Views.ArkViews
{
    public interface IArkViewService
    {
        ValueTask<List<ArkView>> RetrieveAllArkViewsAsync();
    }
}
