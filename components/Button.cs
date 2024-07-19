// Button.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;
using Godot;

namespace EasyDebugMenu.Components;

public partial class Button : Element
{
    private string _title;
    private Action _onClick;
    private bool _enabled;
    private Godot.Button _button;
    
    internal Button(string title, Action onClick, bool enabled = true)
    {
        _button = new Godot.Button();
        _button.Name = $"Button_{title.Replace(' ', '_')}";
        _button.Text = title;
        
        _title = title;
        _onClick = onClick;
        _enabled = enabled;
    }

    public override void ReDraw()
    {
        throw new System.NotImplementedException();
    }
}