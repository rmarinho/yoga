using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Facebook.Yoga;
using System;

namespace Facebook.YogaKit.Android.Sample
{
	[Activity(Label = "Facebook.YogaKit.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			var abs = new AbsoluteLayout(this);

			var width = this.Resources.DisplayMetrics.WidthPixels;
			var height = this.Resources.DisplayMetrics.HeightPixels;
			CreateViewHierarchy(abs, width, height);
			SetContentView(abs);
		}

		static void CreateViewHierarchy(ViewGroup root, float width, float height)
		{
			root.SetBackgroundColor(Color.Red);
			root.Yoga().IsEnabled = true;

			root.Yoga().Width = width;
			root.Yoga().Height = height;
			root.Yoga().AlignItems = YogaAlign.Center;
			root.Yoga().JustifyContent = YogaJustify.Center;

			var child1 = new View(root.Context);
			child1.SetBackgroundColor(Color.Blue);
			child1.Yoga().IsEnabled = true;
			child1.Yoga().Width = 100;
			child1.Yoga().Height = 100;

			var child2 = new AbsoluteLayout(root.Context);
			child2.LayoutParameters = new AbsoluteLayout.LayoutParams(200, 100, 0, 0);
			child2.SetBackgroundColor(Color.Green);

			var child3 = new View(root.Context);
			child3.SetBackgroundColor(Color.Yellow);
			child3.LayoutParameters = new AbsoluteLayout.LayoutParams(100, 100, 0, 0);

			child2.AddView(child3);
			root.AddView(child1);
			root.AddView(child2);
			root.Yoga().ApplyLayout();
		}
	}
}

