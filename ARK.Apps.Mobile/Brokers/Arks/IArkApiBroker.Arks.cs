// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Models.Arks;

namespace ARK.Apps.Mobile.Brokers.Arks
{
    internal partial interface IArkApiBroker
    {
        ValueTask<List<Ark>> GetAllArksAsync();
    }
}
