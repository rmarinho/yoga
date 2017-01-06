﻿using System;
using CoreGraphics;
using Facebook.Yoga;
using UIKit;

namespace Facebook.YogaKit.iOS.Sample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateViewHierarchy(View, View.Bounds.Size.Width, View.Bounds.Size.Height);
        }

        static void CreateViewHierarchy(UIView root, nfloat width, nfloat height)
        {
            root.BackgroundColor = UIColor.Red;

            root.UsesYoga(true);
            root.YogaWidth(width);
            root.YogaWidth(height);
            root.YogaAlignItems(YogaAlign.Center);
            root.YogaJustify(YogaJustify.Center);

            var child1 = new UIView { BackgroundColor = UIColor.Blue };
            child1.YogaWidth(100);
            child1.YogaHeight(100);
            child1.UsesYoga(true);

            var child2 = new UIView
            {
                BackgroundColor = UIColor.Green,
                Frame = new CGRect { Size = new CGSize(200, 100) }
            };

            var child3 = new UIView
            {
                BackgroundColor = UIColor.Yellow,
                Frame = new CGRect { Size = new CGSize(100, 100) }
            };

            child2.AddSubview(child3);
            root.AddSubview(child1);
            root.AddSubview(child2);
            root.YogaApplyLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}