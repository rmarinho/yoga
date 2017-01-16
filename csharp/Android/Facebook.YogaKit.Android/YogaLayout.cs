using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Facebook.Yoga;
using NativeView = global::Android.Views.View;
using ViewGroup = global::Android.Views.ViewGroup;

namespace Facebook.YogaKit
{
	public partial class YogaLayout : Java.Lang.Object
	{

		static void MeasureNativeView(NativeView view, float constrainedWidth, float constrainedHeight, out float sizeThatFitsWidth, out float sizeThatFitsHeight)
		{
			view.Measure(MeasureSpecFactory.MakeMeasureSpec((int)constrainedWidth, MeasureSpecMode.AtMost), MeasureSpecFactory.MakeMeasureSpec((int)constrainedHeight, MeasureSpecMode.AtMost));
			var absParameters = view.LayoutParameters as AbsoluteLayout.LayoutParams;

			if (absParameters != null)
			{
				sizeThatFitsWidth = absParameters.Width;
				sizeThatFitsHeight = absParameters.Height;
			}
			else
			{
				sizeThatFitsWidth = view.MeasuredWidth;
				sizeThatFitsHeight = view.MeasuredHeight;
			}
		}

		static void GetWidthHeightOfNativeView(NativeView view, out float width, out float height)
		{
			int widthMax = 2000;
			int heightMax = 2000;
			view.Measure(MeasureSpecFactory.MakeMeasureSpec(widthMax, MeasureSpecMode.AtMost), MeasureSpecFactory.MakeMeasureSpec(heightMax, MeasureSpecMode.AtMost));
			width = view.MeasuredWidth;
			height = view.MeasuredHeight;
		}

		static float NativePixelScale => 1;

		static void ApplyLayoutToNativeView(NativeView view, PointF topLeft, PointF bottomRight)
		{
			var width = (int)(bottomRight.X - topLeft.X);
			var height = (int)(bottomRight.Y - topLeft.Y);
			System.Diagnostics.Debug.WriteLine($"{topLeft},{bottomRight}");

			//say to the view the size we are going to apply 
			view.Measure(MeasureSpecFactory.MakeMeasureSpec(width, MeasureSpecMode.Exactly), MeasureSpecFactory.MakeMeasureSpec(height, MeasureSpecMode.Exactly));

			//apply the parameters inside our possible Layout
			if (view.LayoutParameters is AbsoluteLayout.LayoutParams)
				view.LayoutParameters = new AbsoluteLayout.LayoutParams((int)width, (int)height, (int)topLeft.X, (int)topLeft.Y);
			view.Layout((int)topLeft.X, (int)topLeft.Y, (int)bottomRight.X, (int)bottomRight.Y);
		}

		static IEnumerable<NativeView> GetChildren(NativeView view)
		{
			var children = new List<NativeView>();
			var viewGroup = (view as ViewGroup);
			for (int i = 0; i < viewGroup?.ChildCount; i++)
			{
				children.Add(viewGroup.GetChildAt(i));
			}
			return children;
		}

		public static class MeasureSpecFactory
		{
			public static int GetSize(int measureSpec)
			{
				const int modeMask = 0x3 << 30;
				return measureSpec & ~modeMask;
			}

			// Literally does the same thing as the android code, 1000x faster because no bridge cross
			// benchmarked by calling 1,000,000 times in a loop on actual device
			public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
			{
				return size + (int)mode;
			}
		}

		bool _disposed;

		protected override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					if (YogaKit.Bridges.ContainsKey(_node))
					{
						YogaKit.Bridges.Remove(_node);
					}
					_node = null;
					_viewRef = null;
				}

				_disposed = true;
			}
		}
	}

	public static class ContextExtensions
	{
		static float s_displayDensity = float.MinValue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double FromPixels(this Context self, double pixels)
		{
			SetupMetrics(self);

			return pixels / s_displayDensity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ToPixels(this Context self, double dp)
		{
			SetupMetrics(self);

			return (float)Math.Round(dp * s_displayDensity);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static void SetupMetrics(Context context)
		{
			if (s_displayDensity != float.MinValue)
				return;

			using (DisplayMetrics metrics = context.Resources.DisplayMetrics)
				s_displayDensity = metrics.Density;
		}
	}
}
