// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingDots;
using Microsoft.AspNetCore.Components;
using SharpStyles.Models;
using SharpStyles.Models.Keyframes;

namespace ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots
{
    public partial class LoadingDotsComponent : ComponentBase
    {
        public StyleBase ComponentStyle { get; set; }
        public LoadingDotsComponentStyle Style { get; set; }
        public LargeHeaderBase LargeHeader { get; set; }
        public ParagraphBase Paragraph { get; set; }
        public DivisionBase DotsLoaderContainerDivision { get; set; }
        public DivisionBase DotsContainerDivision { get; set; }
        public DivisionBase Dot0Division { get; set; }
        public DivisionBase Dot1Division { get; set; }
        public DivisionBase Dot2Division { get; set; }

        protected override void OnInitialized() =>
            this.Style = SetupStyles();

        private LoadingDotsComponentStyle SetupStyles()
        {
            return new LoadingDotsComponentStyle
            {
                LargeHeader = new SharpStyle
                {
                    FontSize = "20px",
                    FontWeight = "600",
                    Color = "rgb(31, 41, 55)",
                    MarginBottom = "24px"
                },

                Paragraph = new SharpStyle
                {
                    Color = "rgb(107, 114, 128)",
                    FontSize = "14px",
                    MarginBottom = "24px"
                },

                DotsContainerDivision = new SharpStyle
                {
                    Display = "flex",
                    JustifyContent = "center",
                    Gap = "4px"
                },

                Dot = new SharpStyle
                {
                    Width = "8px",
                    Height = "8px",
                    Background = "#d8b4fe",
                    BorderRadius = "50%",
                    Animation = "bounce 1.4s infinite ease-in-out"
                },

                Dot0Division = new SharpStyle
                {
                    AnimationDelay = "0ms"
                },

                Dot1Division = new SharpStyle
                {
                    AnimationDelay = ".15s"
                },

                Dot2Division = new SharpStyle
                {
                    AnimationDelay = ".3s"
                },

                Keyframes = new List<SharpKeyframes>
                {
                    new SharpKeyframes
                    {
                        Name = "bounce",

                        Keyframes = new List<SharpKeyframe>
                        {
                            new SharpKeyframe
                            {
                                Selector = "0%, 80%, 100%",

                                Properties = new List<SharpKeyframeProperty>
                            {
                            new SharpKeyframeProperty
                            {
                                Name = "transform",
                                Value = "scale(0)"
                            }
                        }
                    },
                            new SharpKeyframe
                            {
                                Selector = "40%",
                                
                                Properties = new List<SharpKeyframeProperty>
                                {
                                    new SharpKeyframeProperty
                                    {
                                        Name = "transform",
                                        Value = "scale(1)"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
