// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Components.Bases;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingSpinners;
using Microsoft.AspNetCore.Components;
using SharpStyles.Models;
using SharpStyles.Models.Keyframes;
using System.Collections.Generic;

namespace ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners
{
    public partial class LoadingSpinnerComponent : ComponentBase
    {
        public DivisionBase Divison { get; set; }
        public SpinnerBase Spinner { get; set; }
        public LoadingSpinnerComponentStyles Styles { get; set; }
        public StyleBase ComponentStyle { get; set; }

        protected override void OnInitialized() =>
            this.Styles = SetupStyles();

        private static LoadingSpinnerComponentStyles SetupStyles()
        {
            return new LoadingSpinnerComponentStyles
            {
                RotatedBox = new SharpStyle
                {
                    Width = "64px",
                    Height = "64px",
                    BackgroundColor = "#f8bbd9",
                    Transform = "rotate(45deg)",
                    Animation = "pulse 1s infinite"
                },

                Spinner = new SharpStyle
                {
                    AlignSelf = "center",
                    JustifyContent = "center"
                },

                SpinnerStroke = new SharpStyle
                {
                    Stroke = "#a855f7",
                    AnimationDuration = "1.5s !important"
                },

                Keyframes = new List<SharpKeyframes>
                {
                    new SharpKeyframes
                    {
                        Name = "pulse",

                        Keyframes = new List<SharpKeyframe>
                        {
                            new SharpKeyframe
                            {
                                Selector = "0%",

                                Properties = new List<SharpKeyframeProperty>
                                {
                                    new SharpKeyframeProperty
                                    {
                                        Name = "opacity",
                                        Value = "0.999231"
                                    }
                                }
                            },

                            new SharpKeyframe
                            {
                                Selector = "50%",

                                Properties = new List<SharpKeyframeProperty>
                                {
                                    new SharpKeyframeProperty
                                    {
                                        Name = "opacity",
                                        Value = "0.5"
                                    }
                                }
                            },

                            new SharpKeyframe
                            {
                                Selector = "100%",

                                Properties = new List<SharpKeyframeProperty>
                                {
                                    new SharpKeyframeProperty
                                    {
                                        Name = "opacity",
                                        Value = "1.0"
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
