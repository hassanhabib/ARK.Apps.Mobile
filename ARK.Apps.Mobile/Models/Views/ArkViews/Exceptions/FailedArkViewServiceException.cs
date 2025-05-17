// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace ARK.Apps.Mobile.Models.Views.ArkViews.Exceptions
{
    internal class FailedArkViewServiceException : Xeption
    {
        public FailedArkViewServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
