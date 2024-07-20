// LayoutGroup.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using System.Diagnostics.CodeAnalysis;
using Godot;

namespace EasyDebugMenu.Components;

[SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
public abstract class Layout<T> : Element<T> where T : FlowContainer 
{
    public virtual HorizontalLayout CreateHorizontalLayout()
    {
        var layout = new HorizontalLayout();
        
        Add(layout.Delegate);
        return layout;
    }

    public virtual VerticalLayout CreateVerticalLayout()
    {
        var layout = new VerticalLayout();
        
        Add(layout.Delegate);
        return layout;
    }
    
    public virtual Button CreateButton(string title, Action onClick, bool enabled = true)
    {
        var button = new Button(title, onClick, enabled);

        Add(button.Delegate);
        return button;
    }

    public virtual void Add(Node child)
    {
        Delegate.AddChild(child);
    }

    public virtual void Remove(Node child)
    {
        Delegate.RemoveChild(child);
        child.QueueFree();
    }
}