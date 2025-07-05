// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using ARK.Apps.Mobile.Components.Components.Foundations.LoadingDots;
using ARK.Apps.Mobile.Models.Components.Foundations.LoadingDots;
using FluentAssertions;
using SharpStyles.Models;
using SharpStyles.Models.Keyframes;

namespace ARK.Apps.Mobile.Tests.Units.Components.Foundations.LoadingDots
{
    public partial class LoadingDotsComponentTests
    {
        [Fact]
        public void ShouldInitializeDefaultValues()
        {
            // given . when
            var initialLoadingDotsComponent =
                new LoadingDotsComponent();

            // then
            initialLoadingDotsComponent
                .ComponentStyle.Should().BeNull();

            initialLoadingDotsComponent
                .LargeHeader.Should().BeNull();

            initialLoadingDotsComponent
                .Paragraph.Should().BeNull();

            initialLoadingDotsComponent.DotsLoaderContainerDivision
                .Should().BeNull();

            initialLoadingDotsComponent
                .DotsContainerDivision.Should()
                    .BeNull();

            initialLoadingDotsComponent
                .Dot0Division.Should().BeNull();

            initialLoadingDotsComponent
                .Dot1Division.Should().BeNull();

            initialLoadingDotsComponent
                .Dot2Division.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderLoadingDotsComponent()
        {
            // given
            string expectedLargeHeaderCssClass =
                "large-header";

            string expectedLargeHeaderText =
                "Finding kindness...";

            string expectedParagraphCssClass =
                "paragraph";

            string expectedParagraphText =
                "Preparing something beautiful for you";

            string expectedDotsContainerCssClass =
                "loading-dots-container";

            string expectedDot0CssClass = "dot dot-0";
            string expectedDot1CssClass = "dot dot-1";
            string expectedDot2CssClass = "dot dot-2";

            // when
            this.renderedLoadingDotsComponent =
                RenderComponent<LoadingDotsComponent>();

            // then
            this.renderedLoadingDotsComponent
                .Instance.ComponentStyle.Should()
                    .NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.LargeHeader.Should()
                    .NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.LargeHeader.CssClass
                    .Should().Be(expectedLargeHeaderCssClass);

            this.renderedLoadingDotsComponent
                .Instance.LargeHeader.Text
                    .Should().Be(expectedLargeHeaderText);

            this.renderedLoadingDotsComponent
                .Instance.Paragraph.Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.Paragraph.CssClass
                    .Should().Be(expectedParagraphCssClass);

            this.renderedLoadingDotsComponent
                .Instance.Paragraph.Text
                    .Should().Be(expectedParagraphText);

            this.renderedLoadingDotsComponent
                .Instance.DotsLoaderContainerDivision
                    .Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.DotsContainerDivision
                    .Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.DotsContainerDivision.CssClass
                    .Should().Be(expectedDotsContainerCssClass);

            this.renderedLoadingDotsComponent
                .Instance.Dot0Division.Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.Dot0Division.CssClass
                    .Should().Be(expectedDot0CssClass);

            this.renderedLoadingDotsComponent
                .Instance.Dot1Division.Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.Dot1Division.CssClass
                    .Should().Be(expectedDot1CssClass);

            this.renderedLoadingDotsComponent
                .Instance.Dot2Division.Should().NotBeNull();

            this.renderedLoadingDotsComponent
                .Instance.Dot2Division.CssClass
                    .Should().Be(expectedDot2CssClass);
        }

        [Fact]
        public void ShouldRenderComponentWithStyles()
        {
            // given
            var expectedComponentStyle =
                new LoadingDotsComponentStyle
                {
                    LargeHeader = new SharpStyle
                    {
                        FontSize = "20px",
                        FontWeight = "600",
                        Color = "rgb(31, 41, 55)"
                    },

                    Paragraph = new SharpStyle
                    {
                        Color = "rgb(107, 114, 128)",
                        FontSize = "14px"
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

            // when
            this.renderedLoadingDotsComponent =
                RenderComponent<LoadingDotsComponent>();

            // then
            this.renderedLoadingDotsComponent.Instance
                .Style.Should().BeEquivalentTo(
                    expectedComponentStyle);
        }
    }
}
