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
    public T Delegate { get; protected set; }

    public void SetProcess(bool enable)
    {
        if (Delegate == null)
        {
            throw new InvalidOperationException("Failed to set active state of element; Delegate was null");
        }
        
        Delegate.SetProcess(enable);
    }

    public bool CanProcess()
    {
        if (Delegate == null)
        {
            throw new InvalidOperationException("Failed to fetch active state of element; Delegate was null");
        }
        
        return Delegate.CanProcess();
    }
}
