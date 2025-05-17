// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace ARK.Apps.Mobile.Services.Views.ArkViews.Exceptions
{
    internal class ArkViewDependencyException : Xeption
    {
        public ArkViewDependencyException(string message, Xeption innerException)
            : base(message, innerException) { }
    }
}
