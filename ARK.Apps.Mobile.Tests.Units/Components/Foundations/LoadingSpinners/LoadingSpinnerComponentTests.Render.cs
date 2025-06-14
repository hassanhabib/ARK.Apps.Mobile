// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingSpinners;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingSpinners;
using Bunit;
using FluentAssertions;
using SharpStyles.Models;
using SharpStyles.Models.Keyframes;

namespace ARK.Apps.Mobile.Tests.Units.Components.Foundations.LoadingSpinners
{
    public partial class LoadingSpinnerComponentTests : TestContext
    {
        [Fact]
        public void ShouldRenderDefaults()
        {
            // given . when
            var initialLoadingSpinnerComponent =
                new LoadingSpinnerComponent();

            // then
            initialLoadingSpinnerComponent.Spinner
                .Should().BeNull();

            initialLoadingSpinnerComponent.ComponentStyle
                .Should().BeNull();

            initialLoadingSpinnerComponent.Divison
                .Should().BeNull();

            initialLoadingSpinnerComponent.Styles
                .Should().BeNull();
        }

        [Fact]
        public void ShouldRenderLoadingSpinnerComponent()
        {
            // given
            string expectedDivisionCssClass = "rotated-box";
            string expectedSpinnerCssClass = "spinner";
            bool expectedIsVisibleFlag = true;
            string expectedSpinnerSize = "32";

            // when
            this.renderedLoadingSpinnerComponent =
                RenderComponent<LoadingSpinnerComponent>();

            // then
            this.renderedLoadingSpinnerComponent
                .Instance.Divison.Should().NotBeNull();

            this.renderedLoadingSpinnerComponent
                .Instance.Divison.CssClass.Should()
                    .Be(expectedDivisionCssClass);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.Should().NotBeNull();

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.CssClass.Should()
                    .Be(expectedSpinnerCssClass);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.IsVisible.Should()
                    .Be(expectedIsVisibleFlag);

            this.renderedLoadingSpinnerComponent
                .Instance.Spinner.Size.Should()
                    .Be(expectedSpinnerSize);

            this.renderedLoadingSpinnerComponent
                .Instance.ComponentStyle.Should()
                    .NotBeNull();
        }

        [Fact]
        public void ShouldRenderComponentWithStyles()
        {
            // given
            var expectedComponentStyles =
                new LoadingSpinnerComponentStyles
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
                        AnimationDuration = "1s !important"
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

            // when
            this.renderedLoadingSpinnerComponent =
                RenderComponent<LoadingSpinnerComponent>();

            // then
            this.renderedLoadingSpinnerComponent.Instance
                .Styles.Should().BeEquivalentTo(
                    expectedComponentStyles);
        }
    }
}
