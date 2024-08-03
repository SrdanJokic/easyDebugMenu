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
    
    public virtual void Push(Node child)
    {
        if (!GodotObject.IsInstanceValid(element1))
        {
            Delegate.AddChild(child);
            element1 = child;
            return;
        }

        if (!GodotObject.IsInstanceValid(element2))
        {
            Delegate.AddChild(child);
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
            element2.QueueFree();
            return;
        }

        if (GodotObject.IsInstanceValid(element1))
        {
            Delegate.RemoveChild(element1);
            element1.QueueFree();
            return;
        }

        throw new InvalidOperationException("Failed to pop a child from a split group. The group is already empty");
    }
}