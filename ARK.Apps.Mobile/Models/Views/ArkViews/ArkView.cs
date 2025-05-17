// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;

namespace ARK.Apps.Mobile.Models.Views.ArkViews
{
    public class ArkView
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Act { get; set; }
    }
}
