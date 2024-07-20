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
using Button = EasyDebugMenu.Components.Button;

namespace EasyDebugMenu;

public static class DebugMenu
{
    public static event Action OnDisplayed;
    public static event Action OnHidden;
    public static event Action<Group> OnGroupAdded;
    public static event Action<Group> OnGroupRemoved;
    
    private static Dictionary<Group, Button> _groups;
    private static VerticalLayout _layout;
    private static Node _root;
    
    public static void Display(Node root)
    {
        _root = root ?? throw new ArgumentNullException(nameof(root));
        _layout ??= new VerticalLayout();

        _root.AddChild(_layout.Delegate);
        OnDisplayed?.Invoke();
    }
    
    public static void Hide()
    {
        if (_root == null || _layout == null)
        {
            return;
        }
        
        _root.RemoveChild(_layout.Delegate);
        OnHidden?.Invoke();
    }
    
    /// <summary>
    /// Adds a group to the list and draws its button.
    /// </summary>
    /// <returns>True if the group was added; otherwise false.</returns>
    public static bool Add(Group group)
    {
        _layout ??= new VerticalLayout();
        _groups ??= new Dictionary<Group, Button>();

        if (!_groups.ContainsKey(group))
        {
            _groups.Add(group, group.CreateToggleButton());
            _layout.Add(_groups[group].Delegate);
            
            OnGroupAdded?.Invoke(group);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes a group from the list and destroys its button and display.
    /// </summary>
    /// <returns>True if the group was removed; otherwise false.</returns>
    public static bool Remove(Group group)
    {
        _layout ??= new VerticalLayout();
        _groups ??= new Dictionary<Group, Button>();

        if (!_groups.ContainsKey(group))
        {
            // TODO: Also, destroy any panel it has spawned
            _layout.Remove(_groups[group].Delegate);
            _groups.Remove(group);
            
            OnGroupRemoved?.Invoke(group);
            return true;
        }

        return false;
    }
}