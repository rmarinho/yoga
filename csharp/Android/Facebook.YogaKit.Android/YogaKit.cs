using System;
using NativeView = global::Android.Views.View;

namespace Facebook.YogaKit
{
	public static partial class YogaKit
	{
		public static IYogaLayout Yoga(this NativeView view)
		{
			return YogaLayoutNative(view);
		}

		static IYogaLayout YogaLayoutNative(NativeView view)
		{
			var yoga = view.Tag as YogaLayout;
			if (yoga == null)
			{
				yoga = new YogaLayout(view);
				view.Tag = yoga;
			}

			return yoga;
		}
	}
}
