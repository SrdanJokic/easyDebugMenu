// Element.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;
using System;

namespace EasyDebugMenu.Components;

public abstract class Element<T> where T : Node
{
    // TODO: Remove as many usages as possible and use the methods under instead
    public T Delegate { get; protected set; }

    public bool HasValidInstance => GodotObject.IsInstanceValid(Delegate);

    public void SetProcess(bool enable)
    {
        if (!HasValidInstance)
        {
            throw new InvalidOperationException("Failed to set active state of element; Delegate was null");
        }
        
        Delegate.SetProcess(enable);
    }

    public bool CanProcess()
    {
        if (!HasValidInstance)
        {
            throw new InvalidOperationException("Failed to fetch active state of element; Delegate was null");
        }
        
        return Delegate.CanProcess();
    }

    public void QueueFree()
    {
        if (!HasValidInstance)
        {
            throw new InvalidOperationException("Failed to free the element; Delegate was null");
        }

        Delegate.Free();
    }
}
