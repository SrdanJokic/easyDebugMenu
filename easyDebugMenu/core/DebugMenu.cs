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
    private static VerticalLayout _buttonsContainer;
    private static HorizontalSplit _root;
    
    public static void Display(Node parent = null)
    {
        if (_root == null)
        {
            _buttonsContainer ??= new VerticalLayout();

            _root = CreateRoot(parent); 
            _root.Push(_buttonsContainer.Delegate);
            OnDisplayed?.Invoke();
        }
        else if (!_root.CanProcess())
        {
            _root.SetProcess(true);
            OnDisplayed?.Invoke();
        }
    }

    private static HorizontalSplit CreateRoot(Node parent = null)
    {
        var root = new HorizontalSplit();
        
        if (GodotObject.IsInstanceValid(parent))
        {
            parent!.AddChild(root.Delegate);
        }

        return root;
    }
    
    public static void Hide()
    {
        if (_root == null)
        {
            // TODO: Throw exception instead
            // TODO: Support silencing exceptions
            // TODO: Add rider attribute for exceptions thrown
            return;
        }

        if (_root.CanProcess())
        {
            _root.SetProcess(false);
            OnHidden?.Invoke();
        }
    }
    
    /// <summary>
    /// Adds a group to the list and draws its button.
    /// </summary>
    /// <returns>True if the group was added; otherwise false.</returns>
    public static bool Add(Group group)
    {
        _buttonsContainer ??= new VerticalLayout();
        _groups ??= new Dictionary<Group, Button>();

        if (!_groups.ContainsKey(group))
        {
            _groups.Add(group, group.CreateToggleButton());
            _buttonsContainer.Add(_groups[group].Delegate);
            
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
        _buttonsContainer ??= new VerticalLayout();
        _groups ??= new Dictionary<Group, Button>();

        if (!_groups.ContainsKey(group))
        {
            // TODO: Also, destroy any panel it has spawned
            _buttonsContainer.Remove(_groups[group].Delegate);
            _groups.Remove(group);
            
            OnGroupRemoved?.Invoke(group);
            return true;
        }

        return false;
    }
}