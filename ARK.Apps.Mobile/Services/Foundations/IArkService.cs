// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;

namespace ARK.Apps.Mobile.Services.Foundations
{
    internal interface IArkService
    {
        ValueTask<List<Ark>> RetrieveAllArksAsync();
    }
}
