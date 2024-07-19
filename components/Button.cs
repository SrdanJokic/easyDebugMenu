// Button.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using Godot;

namespace EasyDebugMenu.Components;

public class Button : Element<Godot.Button>
{
    private string _title;
    private Action _onClick;
    private bool _enabled;
    
    internal Button(string title, Action onClick, bool enabled = true)
    {
        Delegate = new Godot.Button();
        Delegate.Name = $"Button_{title.Replace(' ', '_')}";
        Delegate.Text = title;
        
        _title = title;
        _onClick = onClick;
        _enabled = enabled;
    }
}