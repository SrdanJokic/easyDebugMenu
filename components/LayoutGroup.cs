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
public abstract class LayoutGroup<T> : Element<T> where T : FlowContainer 
{
    public virtual HorizontalLayoutGroup CreateHorizontalLayoutGroup()
    {
        var hGroup = new HorizontalLayoutGroup();
        
        Delegate.AddChild(hGroup.Delegate);
        return hGroup;
    }
    
    public virtual Button CreateButton(string title, Action onClick, bool enabled = true)
    {
        var button = new Button(title, onClick, enabled);

        Delegate.AddChild(button.Delegate);
        return button;
    }
    
    public abstract void Clear();
}