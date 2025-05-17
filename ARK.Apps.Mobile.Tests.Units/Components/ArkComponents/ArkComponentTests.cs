// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using ARK.Apps.Mobile.Components.Components;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Syncfusion.Blazor;
using Tynamix.ObjectFiller;

namespace ARK.Apps.Mobile.Tests.Units.Components.ArkComponents
{
    public partial class ArkComponentTests : TestContext
    {
        private readonly Mock<IArkViewService> arkViewServiceMock;
        private IRenderedComponent<ArkComponent> renderedArkComponent;

        public ArkComponentTests()
        {
            this.arkViewServiceMock =
                new Mock<IArkViewService>();

            this.Services.AddTransient(service =>
                this.arkViewServiceMock.Object);

            this.Services.AddSyncfusionBlazor();
        }

        private static List<ArkView> CreateRandomArkViews()
        {
            return CreateArkViewFiller()
                .Create(count: GetRandomNumber())
                    .ToList();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<ArkView> CreateArkViewFiller()
        {
            var filler = new Filler<ArkView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(GetRandomDateTime);

            return filler;
        }
    }
}
