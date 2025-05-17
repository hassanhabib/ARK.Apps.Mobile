// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace ARK.Apps.Mobile.Models.Views.ArkViews.Exceptions
{
    internal class ArkViewServiceException : Xeption
    {
        public ArkViewServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
