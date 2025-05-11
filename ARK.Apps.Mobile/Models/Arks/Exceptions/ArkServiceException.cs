// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace ARK.Apps.Mobile.Models.Arks.Exceptions
{
    internal class ArkServiceException : Xeption
    {
        public ArkServiceException(string message, Xeption innerException)
            : base(message, innerException) { }
    }
}
