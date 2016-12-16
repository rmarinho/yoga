/**
 * Copyright (c) 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

 // @Generated by gentest/gentest.rb from gentest/fixtures/YGMinMaxDimensionTest.html

using System;
using NUnit.Framework;

namespace Facebook.Yoga
{
    [TestFixture]
    public class YGMinMaxDimensionTest
    {
        [Test]
        public void Test_max_width()
        {
            YogaNode root = new YogaNode();
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.MaxWidth = 50;
            root_child0.Height = 10;
            root.Insert(0, root_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(10f, root_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(50f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(10f, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_max_height()
        {
            YogaNode root = new YogaNode();
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.Width = 10;
            root_child0.MaxHeight = 50;
            root.Insert(0, root_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(10f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(90f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(10f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_min_height()
        {
            YogaNode root = new YogaNode();
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexGrow = 1;
            root_child0.MinHeight = 60;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.FlexGrow = 1;
            root.Insert(1, root_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(80f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(80f, root_child1.LayoutY);
            Assert.AreEqual(100f, root_child1.LayoutWidth);
            Assert.AreEqual(20f, root_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(80f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(80f, root_child1.LayoutY);
            Assert.AreEqual(100f, root_child1.LayoutWidth);
            Assert.AreEqual(20f, root_child1.LayoutHeight);
        }

        [Test]
        public void Test_min_width()
        {
            YogaNode root = new YogaNode();
            root.FlexDirection = YogaFlexDirection.Row;
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexGrow = 1;
            root_child0.MinWidth = 60;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.FlexGrow = 1;
            root.Insert(1, root_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(80f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(80f, root_child1.LayoutX);
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(20f, root_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(20f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(80f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(20f, root_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child1.LayoutHeight);
        }

        [Test]
        public void Test_justify_content_min_max()
        {
            YogaNode root = new YogaNode();
            root.JustifyContent = YogaJustify.Center;
            root.Width = 100;
            root.MinHeight = 100;
            root.MaxHeight = 200;

            YogaNode root_child0 = new YogaNode();
            root_child0.Width = 60;
            root_child0.Height = 60;
            root.Insert(0, root_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(20f, root_child0.LayoutY);
            Assert.AreEqual(60f, root_child0.LayoutWidth);
            Assert.AreEqual(60f, root_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(40f, root_child0.LayoutX);
            Assert.AreEqual(20f, root_child0.LayoutY);
            Assert.AreEqual(60f, root_child0.LayoutWidth);
            Assert.AreEqual(60f, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_align_items_min_max()
        {
            YogaNode root = new YogaNode();
            root.AlignItems = YogaAlign.Center;
            root.MinWidth = 100;
            root.MaxWidth = 200;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.Width = 60;
            root_child0.Height = 60;
            root.Insert(0, root_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(20f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(60f, root_child0.LayoutWidth);
            Assert.AreEqual(60f, root_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(20f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(60f, root_child0.LayoutWidth);
            Assert.AreEqual(60f, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_justify_content_overflow_min_max()
        {
            YogaNode root = new YogaNode();
            root.JustifyContent = YogaJustify.Center;
            root.MinHeight = 100;
            root.MaxHeight = 110;

            YogaNode root_child0 = new YogaNode();
            root_child0.Width = 50;
            root_child0.Height = 50;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.Width = 50;
            root_child1.Height = 50;
            root.Insert(1, root_child1);

            YogaNode root_child2 = new YogaNode();
            root_child2.Width = 50;
            root_child2.Height = 50;
            root.Insert(2, root_child2);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(50f, root.LayoutWidth);
            Assert.AreEqual(110f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(-20f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(30f, root_child1.LayoutY);
            Assert.AreEqual(50f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);

            Assert.AreEqual(0f, root_child2.LayoutX);
            Assert.AreEqual(80f, root_child2.LayoutY);
            Assert.AreEqual(50f, root_child2.LayoutWidth);
            Assert.AreEqual(50f, root_child2.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(50f, root.LayoutWidth);
            Assert.AreEqual(110f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(-20f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(30f, root_child1.LayoutY);
            Assert.AreEqual(50f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);

            Assert.AreEqual(0f, root_child2.LayoutX);
            Assert.AreEqual(80f, root_child2.LayoutY);
            Assert.AreEqual(50f, root_child2.LayoutWidth);
            Assert.AreEqual(50f, root_child2.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_max_width()
        {
            YogaNode root = new YogaNode();
            root.Width = 200;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexDirection = YogaFlexDirection.Row;
            root_child0.MaxWidth = 100;
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode();
            root_child0_child0.FlexGrow = 1;
            root_child0_child0.Height = 20;
            root_child0.Insert(0, root_child0_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(100f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(100f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(100f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0_child0.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_constrained_max_width()
        {
            YogaNode root = new YogaNode();
            root.Width = 200;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexDirection = YogaFlexDirection.Row;
            root_child0.MaxWidth = 300;
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode();
            root_child0_child0.FlexGrow = 1;
            root_child0_child0.Height = 20;
            root_child0.Insert(0, root_child0_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(200f, root_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(200f, root_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(20f, root_child0_child0.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_constrained_min_row()
        {
            YogaNode root = new YogaNode();
            root.FlexDirection = YogaFlexDirection.Row;
            root.MinWidth = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexGrow = 1;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.Width = 50;
            root.Insert(1, root_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(50f, root_child1.LayoutX);
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(50f, root_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(50f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(50f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(0f, root_child1.LayoutY);
            Assert.AreEqual(50f, root_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child1.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_constrained_min_column()
        {
            YogaNode root = new YogaNode();
            root.MinHeight = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexGrow = 1;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.Height = 50;
            root.Insert(1, root_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(0f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(0f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(50f, root_child1.LayoutY);
            Assert.AreEqual(0f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(0f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(0f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(50f, root_child1.LayoutY);
            Assert.AreEqual(0f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_constrained_max_row()
        {
            YogaNode root = new YogaNode();
            root.Width = 200;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexDirection = YogaFlexDirection.Row;
            root_child0.MaxWidth = 100;
            root_child0.Height = 100;
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode();
            root_child0_child0.FlexShrink = 1;
            root_child0_child0.FlexBasis = 100;
            root_child0.Insert(0, root_child0_child0);

            YogaNode root_child0_child1 = new YogaNode();
            root_child0_child1.Width = 50;
            root_child0.Insert(1, root_child0_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(50f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0_child0.LayoutHeight);

            Assert.AreEqual(50f, root_child0_child1.LayoutX);
            Assert.AreEqual(0f, root_child0_child1.LayoutY);
            Assert.AreEqual(50f, root_child0_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child0_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(200f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(100f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(50f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(50f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child1.LayoutX);
            Assert.AreEqual(0f, root_child0_child1.LayoutY);
            Assert.AreEqual(50f, root_child0_child1.LayoutWidth);
            Assert.AreEqual(100f, root_child0_child1.LayoutHeight);
        }

        [Test]
        public void Test_flex_grow_within_constrained_max_column()
        {
            YogaNode root = new YogaNode();
            root.Width = 100;
            root.MaxHeight = 100;

            YogaNode root_child0 = new YogaNode();
            root_child0.FlexShrink = 1;
            root_child0.FlexBasis = 100;
            root.Insert(0, root_child0);

            YogaNode root_child1 = new YogaNode();
            root_child1.Height = 50;
            root.Insert(1, root_child1);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(50f, root_child1.LayoutY);
            Assert.AreEqual(100f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(50f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child1.LayoutX);
            Assert.AreEqual(50f, root_child1.LayoutY);
            Assert.AreEqual(100f, root_child1.LayoutWidth);
            Assert.AreEqual(50f, root_child1.LayoutHeight);
        }

    }
}
