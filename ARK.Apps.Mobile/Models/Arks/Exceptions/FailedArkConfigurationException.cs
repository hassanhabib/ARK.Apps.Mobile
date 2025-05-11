// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace ARK.Apps.Mobile.Models.Arks.Exceptions
{
    internal class FailedArkConfigurationException : Xeption
    {
        public FailedArkConfigurationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
