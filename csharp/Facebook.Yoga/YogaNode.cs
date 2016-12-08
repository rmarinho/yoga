﻿/**
 * Copyright (c) 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Facebook.Yoga
{
    public partial class YogaNode : IEnumerable<YogaNode>
    {
        private IntPtr _ygNode;
        private WeakReference _parent;
        private List<YogaNode> _children;
        private MeasureFunction _measureFunction;
        private YogaMeasureFunc _ygMeasureFunc;
        private object _data;

        public YogaNode()
        {
            YogaLogger.Initialize();

            _ygNode = Native.YGNodeNew();
            if (_ygNode == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to allocate native memory");
            }
        }

        ~YogaNode()
        {
            Native.YGNodeFree(_ygNode);
        }

        public void Reset()
        {
            _measureFunction = null;
            _data = null;

            Native.YGNodeReset(_ygNode);
        }

        public bool IsDirty
        {
            get
            {
                return Native.YGNodeIsDirty(_ygNode);
            }
        }

        public virtual void MarkDirty()
        {
            Native.YGNodeMarkDirty(_ygNode);
        }

        public bool HasNewLayout
        {
            get
            {
                return Native.YGNodeGetHasNewLayout(_ygNode);
            }
        }

        public void MarkHasNewLayout()
        {
            Native.YGNodeSetHasNewLayout(_ygNode, true);
        }

        public YogaNode Parent
        {
            get
            {
                return _parent != null ? _parent.Target as YogaNode : null;
            }
        }

        public bool IsMeasureDefined
        {
            get
            {
                return _measureFunction != null;
            }
        }

        public void CopyStyle(YogaNode srcNode)
        {
            Native.YGNodeCopyStyle(_ygNode, srcNode._ygNode);
        }

        public YogaDirection StyleDirection
        {
            get
            {
                return Native.YGNodeStyleGetDirection(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetDirection(_ygNode, value);
            }
        }

        public YogaFlexDirection FlexDirection
        {
            get
            {
                return Native.YGNodeStyleGetFlexDirection(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetFlexDirection(_ygNode, value);
            }
        }

        public YogaJustify JustifyContent
        {
            get
            {
                return Native.YGNodeStyleGetJustifyContent(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetJustifyContent(_ygNode, value);
            }
        }

        public YogaAlign AlignItems
        {
            get
            {
                return Native.YGNodeStyleGetAlignItems(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetAlignItems(_ygNode, value);
            }
        }

        public YogaAlign AlignSelf
        {
            get
            {
                return Native.YGNodeStyleGetAlignSelf(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetAlignSelf(_ygNode, value);
            }
        }

        public YogaAlign AlignContent
        {
            get
            {
                return Native.YGNodeStyleGetAlignContent(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetAlignContent(_ygNode, value);
            }
        }

        public YogaPositionType PositionType
        {
            get
            {
                return Native.YGNodeStyleGetPositionType(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetPositionType(_ygNode, value);
            }
        }

        public YogaWrap Wrap
        {
            get
            {
                return Native.YGNodeStyleGetFlexWrap(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetFlexWrap(_ygNode, value);
            }
        }

        public float Flex
        {
            set
            {
                Native.YGNodeStyleSetFlex(_ygNode, value);
            }
        }

        public float FlexGrow
        {
            get
            {
                return Native.YGNodeStyleGetFlexGrow(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetFlexGrow(_ygNode, value);
            }
        }

        public float FlexShrink
        {
            get
            {
                return Native.YGNodeStyleGetFlexShrink(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetFlexShrink(_ygNode, value);
            }
        }

        public float FlexBasis
        {
            get
            {
                return Native.YGNodeStyleGetFlexBasis(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetFlexBasis(_ygNode, value);
            }
        }

        public float GetMargin(YogaEdge edge)
        {
            return Native.YGNodeStyleGetMargin(_ygNode, edge);
        }

        public void SetMargin(YogaEdge edge, float value)
        {
            Native.YGNodeStyleSetMargin(_ygNode, edge, value);
        }

        public float GetPadding(YogaEdge edge)
        {
            return Native.YGNodeStyleGetPadding(_ygNode, edge);
        }

        public void SetPadding(YogaEdge edge, float padding)
        {
            Native.YGNodeStyleSetPadding(_ygNode, edge, padding);
        }

        public float GetBorder(YogaEdge edge)
        {
            return Native.YGNodeStyleGetBorder(_ygNode, edge);
        }

        public void SetBorder(YogaEdge edge, float border)
        {
            Native.YGNodeStyleSetBorder(_ygNode, edge, border);
        }

        public float GetPosition(YogaEdge edge)
        {
            return Native.YGNodeStyleGetPosition(_ygNode, edge);
        }

        public void SetPosition(YogaEdge edge, float position)
        {
            Native.YGNodeStyleSetPosition(_ygNode, edge, position);
        }

        public float Width
        {
            get
            {
                return Native.YGNodeStyleGetWidth(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetWidth(_ygNode, value);
            }
        }

        public float Height
        {
            get
            {
                return Native.YGNodeStyleGetHeight(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetHeight(_ygNode, value);
            }
        }

        public float MaxWidth
        {
            get
            {
                return Native.YGNodeStyleGetMaxWidth(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetMaxWidth(_ygNode, value);
            }
        }

        public float MaxHeight
        {
            get
            {
                return Native.YGNodeStyleGetMaxHeight(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetMaxHeight(_ygNode, value);
            }
        }

        public float MinWidth
        {
            get
            {
                return Native.YGNodeStyleGetMinWidth(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetMinWidth(_ygNode, value);
            }
        }

        public float MinHeight
        {
            get
            {
                return Native.YGNodeStyleGetMinHeight(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetMinHeight(_ygNode, value);
            }
        }

        public float StyleAspectRatio
        {
            get
            {
                return Native.YGNodeStyleGetAspectRatio(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetAspectRatio(_ygNode, value);
            }
        }

        public float LayoutX
        {
            get
            {
                return Native.YGNodeLayoutGetLeft(_ygNode);
            }
        }

        public float LayoutY
        {
            get
            {
                return Native.YGNodeLayoutGetTop(_ygNode);
            }
        }

        public float LayoutWidth
        {
            get
            {
                return Native.YGNodeLayoutGetWidth(_ygNode);
            }
        }

        public float LayoutHeight
        {
            get
            {
                return Native.YGNodeLayoutGetHeight(_ygNode);
            }
        }

        public YogaDirection LayoutDirection
        {
            get
            {
                return Native.YGNodeLayoutGetDirection(_ygNode);
            }
        }

        public YogaOverflow Overflow
        {
            get
            {
                return Native.YGNodeStyleGetOverflow(_ygNode);
            }

            set
            {
                Native.YGNodeStyleSetOverflow(_ygNode, value);
            }
        }

        public object Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public YogaNode this[int index]
        {
            get
            {
                return _children[index];
            }
        }

        public int Count
        {
            get
            {
                return _children != null ? _children.Count : 0;
            }
        }

        public void MarkLayoutSeen()
        {
            Native.YGNodeSetHasNewLayout(_ygNode, false);
        }

        public bool ValuesEqual(float f1, float f2)
        {
            if (float.IsNaN(f1) || float.IsNaN(f2))
            {
                return float.IsNaN(f1) && float.IsNaN(f2);
            }

            return Math.Abs(f2 - f1) < float.Epsilon;
        }

        public void Insert(int index, YogaNode node)
        {
            if (_children == null)
            {
                _children = new List<YogaNode>(4);
            }
            _children.Insert(index, node);
            node._parent = new WeakReference(this);
            Native.YGNodeInsertChild(_ygNode, node._ygNode, (uint)index);
        }

        public void RemoveAt(int index)
        {
            var child = _children[index];
            child._parent = null;
            _children.RemoveAt(index);
            Native.YGNodeRemoveChild(_ygNode, child._ygNode);
        }

        public void Clear()
        {
            if (_children != null)
            {
                while (_children.Count > 0)
                {
                    RemoveAt(_children.Count-1);
                }
            }
        }

        public int IndexOf(YogaNode node)
        {
            return _children != null ? _children.IndexOf(node) : -1;
        }

        public void SetMeasureFunction(MeasureFunction measureFunction)
        {
            _measureFunction = measureFunction;
            _ygMeasureFunc = measureFunction != null ? MeasureInternal : (YogaMeasureFunc)null;
            Native.YGNodeSetMeasureFunc(_ygNode, _ygMeasureFunc);
        }

        public void CalculateLayout()
        {
            Native.YGNodeCalculateLayout(
                _ygNode,
                YogaConstants.Undefined,
                YogaConstants.Undefined,
                Native.YGNodeStyleGetDirection(_ygNode));
        }

        private YogaSize MeasureInternal(
            IntPtr node,
            float width,
            YogaMeasureMode widthMode,
            float height,
            YogaMeasureMode heightMode)
        {
            if (_measureFunction == null)
            {
                throw new InvalidOperationException("Measure function is not defined.");
            }

            long output = _measureFunction(this, width, widthMode, height, heightMode);
            return new YogaSize { width = MeasureOutput.GetWidth(output), height = MeasureOutput.GetHeight(output) };
        }
#if !__IOS__
        public string Print(YogaPrintOptions options =
            YogaPrintOptions.Layout|YogaPrintOptions.Style|YogaPrintOptions.Children)
        {
            StringBuilder sb = new StringBuilder();
            YogaLogger.Func orig = YogaLogger.Logger;
            YogaLogger.Logger = (level, message) => {sb.Append(message);};
            Native.YGNodePrint(_ygNode, options);
            YogaLogger.Logger = orig;
            return sb.ToString();
        }
#endif
        public IEnumerator<YogaNode> GetEnumerator()
        {
            return _children != null ? ((IEnumerable<YogaNode>)_children).GetEnumerator() :
                System.Linq.Enumerable.Empty<YogaNode>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children != null ? ((IEnumerable<YogaNode>)_children).GetEnumerator() :
                System.Linq.Enumerable.Empty<YogaNode>().GetEnumerator();
        }

        public static int GetInstanceCount()
        {
            return Native.YGNodeGetInstanceCount();
        }

        public static void SetExperimentalFeatureEnabled(
            YogaExperimentalFeature feature,
            bool enabled)
        {
            Native.YGSetExperimentalFeatureEnabled(feature, enabled);
        }

        public static bool IsExperimentalFeatureEnabled(YogaExperimentalFeature feature)
        {
            return Native.YGIsExperimentalFeatureEnabled(feature);
        }
    }
}
