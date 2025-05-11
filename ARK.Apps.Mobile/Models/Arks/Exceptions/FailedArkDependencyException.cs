// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace ARK.Apps.Mobile.Models.Arks.Exceptions
{
    internal class FailedArkDependencyException : Xeption
    {
        public FailedArkDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
