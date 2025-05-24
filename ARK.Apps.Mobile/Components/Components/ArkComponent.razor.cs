// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Models.Views.ArkViews;
using ARK.Apps.Mobile.Models.Views.Components.ArkComponents;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Microsoft.AspNetCore.Components;

namespace ARK.Apps.Mobile.Components.Components
{
    public partial class ArkComponent : ComponentBase
    {
        [Inject]
        public IArkViewService ArkViewService { get; set; }
        public ArkComponentState State { get; set; }
        public LabelBase LoadingLabel { get; set; }
        public LabelBase ErrorLabel { get; set; }

        public CarouselBase Carousel { get; set; }
        public List<ArkView> ArkViews { get; set; } = new List<ArkView>();

        protected async override Task OnInitializedAsync()
        {
            this.State = ArkComponentState.Loading;

            this.ArkViews = await this.ArkViewService
                .RetrieveAllArkViewsAsync();

            this.State = ArkComponentState.Content;
        }

        private bool IsLoadingState() =>
            this.State == ArkComponentState.Loading;
    }
}
