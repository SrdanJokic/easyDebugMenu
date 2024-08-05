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
    public bool IsContentShown => _content != null;
    
    private VerticalLayout _content;
    
    public bool Toggle(HorizontalSplit parent)
    {
        if (IsContentShown)
        {
            _content.QueueFree();
            _content = null;
        }
        else
        {
            if (parent == null || !parent.HasValidInstance)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            
            _content = new VerticalLayout();
            parent.Push(_content.Delegate);
        }

        return IsContentShown;
    }
}