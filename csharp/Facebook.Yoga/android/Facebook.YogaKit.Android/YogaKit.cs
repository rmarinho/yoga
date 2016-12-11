using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Facebook.Yoga;
using AView = global::Android.Views.View;

namespace Facebook.YogaKit.Android
{

	class YGNodeBridge
	{
		bool disposed;
		internal WeakReference<AView> viewRef;
		internal YogaNode node;
		public YGNodeBridge()
		{
			node = new YogaNode();
		}

		public void SetContext(AView view)
		{
			viewRef = new WeakReference<AView>(view);
			YogaKit.Bridges.Add(node, this);
		}

		public bool UsesYoga
		{
			get;
			set;
		}
		public bool IncludeYogaLayout
		{
			get;
			set;
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing && !disposed)
		//	{
		//		disposed = true;
		//		YogaKit.Bridges.Remove(node);
		//		viewRef = null;
		//		node = null;
		//	}
		//	base.Dispose(disposing);
		//}
	}

	public static class YogaKit
	{
		internal static Dictionary<YogaNode, YGNodeBridge> Bridges = new Dictionary<YogaNode, YGNodeBridge>();

		internal static Dictionary<AView, YogaNode> Nodes = new Dictionary<AView, YogaNode>();


		public static void SetUsesYoga<T>(this T view, bool usesYoga)
		{
			var node = GetYogaNode(view);
			var bridge = Bridges[node];
			bridge.UsesYoga = usesYoga;
		}

		public static bool GetUsesYoga<T>(this T view)
		{
			var node = GetYogaNode(view);
			var bridge = Bridges[node];
			return bridge.UsesYoga;
		}

		public static void SetIncludeYogaLayout<T>(this T view, bool includeInLayout)
		{
			var node = GetYogaNode(view);
			var bridge = Bridges[node];
			bridge.IncludeYogaLayout = includeInLayout;
		}

		public static bool GetIncludeYogaLayout<T>(this T view)
		{
			var node = GetYogaNode(view);
			var bridge = Bridges[node];
			return bridge.IncludeYogaLayout;
		}

		static YogaNode GetYogaNode<T>(this T view)
		{
			YogaNode node = null;
			if (Nodes.ContainsKey(view as AView))
			{
				node = Nodes[view as AView];
				return node;
			}
			node = new YogaNode();
			var bridge = new YGNodeBridge();
			Nodes.Add(view as AView, node);
			Bridges.Add(node, bridge);
			return node;
		}

		public static void YogaWidth<T>(this T view, float width)
		{
			var node = GetYogaNode(view);
			node.Width = (float)width;
		}

		public static void YogaHeight<T>(this T view, float height)
		{
			var node = GetYogaNode(view);
			node.Height = (float)height;
		}

		public static void YogaMinWidth<T>(this T view, float minWidth)
		{
			var node = GetYogaNode(view);
			node.MinWidth = minWidth;
		}

		public static void YogaMinHeight<T>(this T view, float minHeight)
		{
			var node = GetYogaNode(view);
			node.MinHeight = minHeight;
		}

		public static void YogaMaxWidth<T>(this T view, float maxWidth)
		{
			var node = GetYogaNode(view);
			node.MaxWidth = maxWidth;
		}

		public static void YogaMaxHeight<T>(this T view, float maxHeight)
		{
			var node = GetYogaNode(view);
			node.MaxHeight = maxHeight;
		}

		public static void YogaAlignItems<T>(this T view, Yoga.YogaAlign align)
		{
			var node = GetYogaNode(view);
			node.AlignItems = align;
		}

		public static void YogaJustify<T>(this T view, Yoga.YogaJustify justify)
		{
			var node = GetYogaNode(view);
			node.JustifyContent = justify;
		}

		public static void YogaAlign<T>(this T view, Yoga.YogaAlign align)
		{
			var node = GetYogaNode(view);
			node.AlignContent = align;
		}

		public static void YogaAlignSelf<T>(this T view, Yoga.YogaAlign align)
		{
			var node = GetYogaNode(view);
			node.AlignSelf = align;
		}

		public static void YogaDirection<T>(this T view, Yoga.YogaDirection direction)
		{
			var node = GetYogaNode(view);
			node.StyleDirection = direction;
		}

		public static void YogaFlexDirection<T>(this T view, Yoga.YogaFlexDirection direction)
		{
			var node = GetYogaNode(view);
			node.FlexDirection = direction;
		}

		public static void YogaPositionType<T>(this T view, Yoga.YogaPositionType position)
		{
			var node = GetYogaNode(view);
			node.PositionType = position;
		}

		public static void YogaFlexWrap<T>(this T view, Yoga.YogaWrap wrap)
		{
			var node = GetYogaNode(view);
			node.Wrap = wrap;
		}

		public static void YogaFlexShrink<T>(this T view, float shrink)
		{
			var node = GetYogaNode(view);
			node.FlexShrink = shrink;
		}

		public static void YogaFlexGrow<T>(this T view, float grow)
		{
			var node = GetYogaNode(view);
			node.FlexGrow = grow;
		}

		public static void YogaFlexBasis<T>(this T view, float basis)
		{
			var node = GetYogaNode(view);
			node.FlexBasis = basis;
		}

		public static void YogaPositionForEdge<T>(this T view, float position, YogaEdge edge)
		{
			var node = GetYogaNode(view);
			node.SetPosition(edge, position);
		}

		public static void YogaMarginForEdge<T>(this T view, float margin, YogaEdge edge)
		{
			var node = GetYogaNode(view);
			node.SetMargin(edge, margin);
		}

		public static void YogaPaddingForEdge<T>(this T view, float padding, YogaEdge edge)
		{
			var node = GetYogaNode(view);
			node.SetPadding(edge, padding);
		}

		public static void YogaAspectRation<T>(this T view, float ratio)
		{
			var node = GetYogaNode(view);
			node.StyleAspectRatio = ratio;
		}

		#region Layout and Sizing
		public static void YogaApplyLayout<T>(this T view)
		{
			var width = 0;
			var height = 0;
			CalculateLayoutWithSize(view, new Size(width, height));
			ApplyLayoutToViewHierarchy(view);
		}

		public static YogaDirection YogaResolvedDirection<T>(this T view)
		{
			var node = GetYogaNode(view);
			return node.LayoutDirection;
		}

		public static Size YogaIntrinsicSize<T>(this T view)
		{
			var constrainedSize = new Size(int.MaxValue, int.MaxValue);
			return CalculateLayoutWithSize(view, constrainedSize);
		}

		#endregion

		static Size CalculateLayoutWithSize<T>(T view, Size size)
		{
			if (!view.GetUsesYoga())
			{
				System.Diagnostics.Debug.WriteLine("Doesn't use Yoga");
			}
			AttachNodesFromViewHierachy(view);
			var node = GetYogaNode(view);

			node.Width = (float)size.Width;
			node.Height = (float)size.Height;
			node.CalculateLayout();

			return new Size((int)node.LayoutWidth, (int)node.LayoutHeight);
		}

		static void AttachNodesFromViewHierachy<T>(T view)
		{

			var node = GetYogaNode(view);

			// Only leaf nodes should have a measure function
			if (!view.GetUsesYoga() || (view as ViewGroup)?.ChildCount == 0)
			{
				node.SetMeasureFunction(MeasureView);
				node.Clear();
			}
			else
			{
				node.SetMeasureFunction(null);
				// Create a list of all the subviews that we are going to use for layout.
				var subviewsToInclude = new List<AView>();

				for (int i = 0; i < (view as ViewGroup)?.ChildCount; i++)
				{
					var subview = (view as ViewGroup).GetChildAt(i);
					if (subview.GetIncludeYogaLayout())
					{
						subviewsToInclude.Add(subview);
					}
				}

				var shouldReconstructChildList = false;
				if (node.Count != subviewsToInclude.Count)
				{
					shouldReconstructChildList = true;
				}
				else
				{
					for (int i = 0; i < subviewsToInclude.Count; i++)
					{
						if (node[i] != GetYogaNode(subviewsToInclude[i]))
						{
							shouldReconstructChildList = true;
							break;
						}
					}
				}

				if (shouldReconstructChildList)
				{
					node.Clear();

					for (int i = 0; i < subviewsToInclude.Count; i++)
					{
						var subView = subviewsToInclude[i];
						node.Insert(i, subView.GetYogaNode());
						AttachNodesFromViewHierachy(subView);
					}
				}
			}
		}

		static void ApplyLayoutToViewHierarchy<T>(T view)
		{
			if (!view.GetIncludeYogaLayout())
				return;

			var node = GetYogaNode(view);
			Point topLeft = new Point((int)node.LayoutX, (int)node.LayoutY);
			Point bottomRight = new Point(topLeft.X + (int)node.LayoutWidth, topLeft.Y + (int)node.LayoutHeight);

			(view as AView).Layout(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
			//	view.Frame = new CGRect(RoundPixelValue(topLeft.X), RoundPixelValue(topLeft.Y), RoundPixelValue(bottomRight.X) - RoundPixelValue(topLeft.X), RoundPixelValue(bottomRight.Y) - RoundPixelValue(topLeft.Y));
			bool isLeaf = !view.GetUsesYoga() || (view as ViewGroup)?.ChildCount == 0;
			if (!isLeaf)
			{
				for (int i = 0; i < (view as ViewGroup).ChildCount; i++)
				{
					ApplyLayoutToViewHierarchy((view as ViewGroup).GetChildAt(i));
				}
			}
		}

		static long MeasureView(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
		{
			var constrainedWidth = (widthMode == YogaMeasureMode.Undefined) ? float.MaxValue : width;
			var constrainedHeight = (heightMode == YogaMeasureMode.Undefined) ? float.MaxValue : height;

			AView view = null;
			if (Bridges.ContainsKey(node))
				Bridges[node].viewRef.TryGetTarget(out view);

			//	var sizeThatFits = view.SizeThatFits(new CGSize(constrainedWidth, constrainedHeight));
			var fitWithSize = width;
			var fitHeightSize = height;

			var finalWidth = SanitizeMeasurement(constrainedWidth, fitWithSize, widthMode);
			var finalHeight = SanitizeMeasurement(constrainedHeight, fitHeightSize, heightMode);

			return MeasureOutput.Make(finalWidth, finalHeight);
		}

		static float SanitizeMeasurement(float constrainedSize, float measuredSize, YogaMeasureMode measureMode)
		{
			float result;
			if (measureMode == YogaMeasureMode.Exactly)
			{
				result = (float)constrainedSize;
			}
			else if (measureMode == YogaMeasureMode.AtMost)
			{
				result = (float)Math.Min(constrainedSize, measuredSize);
			}
			else {
				result = (float)measuredSize;
			}

			return result;

		}
	}
}
