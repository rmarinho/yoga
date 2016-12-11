using Android.App;
using Android.Widget;
using Android.OS;
using AView = global::Android.Views.View;
using Facebook.YogaKit.Android;
using Android.Content;
using Android.Graphics;
using Android.Views;
using System;

namespace Facebook.Yoga.Android.Test
{
	[Activity(Label = "Facebook.Yoga.Android.Test", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var width = Resources.DisplayMetrics.WidthPixels;
			var height = Resources.DisplayMetrics.HeightPixels;

			var root = new CustomLayout(this);
			CreateViewHierarchy(root, width, height, this);

			SetContentView(root);

		}

		public class CustomLayout : ViewGroup
		{
			public CustomLayout(Context context) : base(context)
			{

			}

			protected override void OnLayout(bool changed, int l, int t, int r, int b)
			{

			}
		}

		static void CreateViewHierarchy(global::Android.Views.ViewGroup root, float width, float height, Context context)
		{
			root.SetBackgroundColor(Color.Red);

			root.SetUsesYoga(true);
			root.YogaWidth(width);
			root.YogaWidth(height);
			root.YogaAlignItems(YogaAlign.Center);
			root.YogaJustify(YogaJustify.Center);

			var child1 = new AView(context);
			child1.SetBackgroundColor(Color.Blue);
			child1.YogaWidth(100);
			child1.YogaHeight(100);
			child1.SetUsesYoga(true);

			global::Android.Views.ViewGroup child2 = new CustomLayout(context);
			child2.SetBackgroundColor(Color.Green);
			child2.SetMinimumWidth(200);
			child2.SetMinimumHeight(100);

			var child3 = new AView(context);
			child3.SetBackgroundColor(Color.Yellow);
			child3.SetMinimumWidth(100);
			child3.SetMinimumHeight(100);

			child2.AddView(child3);
			root.AddView(child1);
			root.AddView(child2);
			root.YogaApplyLayout();
		}
	}
}

