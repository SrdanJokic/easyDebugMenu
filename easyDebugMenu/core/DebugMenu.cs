// DebugMenu.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using System.Collections.Generic;
using EasyDebugMenu.Components;
using Godot;

namespace EasyDebugMenu;

public static class DebugMenu
{
    public static event Action OnDisplayed;
    public static event Action OnHidden;

    private static List<Group> _groups;
    
    // TODO: Add alignment options
    public static void Display(Node root)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        
        var layout = new HorizontalLayout();
        root.AddChild(layout.Delegate);
        
        var horizontal = layout.CreateHorizontalLayout();
        horizontal.CreateButton("Title", null);
        
        OnDisplayed?.Invoke();
    }

    private static void Draw()
    {
        
    }
    
    public static void Add(Group group)
    {
        _groups.Add(group);
    }

    public static void Hide()
    {
        // TODO: Hide all elements
        OnHidden?.Invoke();
    }
}