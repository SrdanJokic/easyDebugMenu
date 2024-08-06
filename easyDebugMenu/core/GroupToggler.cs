// GroupToggler.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using EasyDebugMenu.Components;
using Godot;

namespace EasyDebugMenu;

public class GroupToggler
{
    public bool IsContentShown => Content != null;
    public VerticalLayout Content { get; private set; }
    
    public bool Toggle(HorizontalSplit parent)
    {
        if (IsContentShown)
        {
            Content.QueueFree();
            Content = null;
        }
        else
        {
            if (parent == null || !parent.HasValidInstance)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            
            Content = new VerticalLayout();
            parent.Push(Content.Delegate);
        }

        return IsContentShown;
    }
}