// Split.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using Godot;

namespace EasyDebugMenu.Components;

public abstract class Split<T> : Element<T> where T : SplitContainer
{
    public Node element1 { get; private set; }
    public Node element2 { get; private set; }

    // These layout presets are used to align the control to a minimum-possible size if it's empty or
    // if it contains only a single element. If the control is full (has both elements), we expand it fully
    protected abstract Control.LayoutPreset OneOrNoChildrenPreset { get; } 
    protected abstract Control.LayoutPreset TwoChildrenPreset { get; }
    
    public virtual void Push(Node child)
    {
        if (!GodotObject.IsInstanceValid(element1))
        {
            Delegate.AddChild(child);
            Delegate.SetAnchorsPreset(OneOrNoChildrenPreset);
            element1 = child;
            return;
        }

        if (!GodotObject.IsInstanceValid(element2))
        {
            Delegate.AddChild(child);
            Delegate.SetAnchorsPreset(TwoChildrenPreset);
            element2 = child;
            return;
        }

        throw new InvalidOperationException("Failed to push a child into the split group. The group already contains a maximum number of elements");
    }

    public virtual void Pop()
    {
        if (GodotObject.IsInstanceValid(element2))
        {
            Delegate.RemoveChild(element2);
            Delegate.SetAnchorsPreset(OneOrNoChildrenPreset);
            element2.QueueFree();
            return;
        }

        if (GodotObject.IsInstanceValid(element1))
        {
            Delegate.RemoveChild(element1);
            Delegate.SetAnchorsPreset(OneOrNoChildrenPreset);
            element1.QueueFree();
            return;
        }

        throw new InvalidOperationException("Failed to pop a child from a split group. The group is already empty");
    }
}