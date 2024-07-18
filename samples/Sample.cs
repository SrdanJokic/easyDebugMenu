using Godot;
using System;
using EasyDebugMenu.Components;
using Button = Godot.Button;

namespace EasyDebugMenu.Samples;

public partial class Sample : Node
{
    private Button _displayButton;
    
    public override void _Ready()
    {
        _displayButton = new Button();
        _displayButton.Text = "Show Easy Debug Menu";
        _displayButton.Pressed += DebugMenu.Display;
        AddChild(_displayButton);
    }

    public override void _EnterTree()
    {
        DebugMenu.OnDisplayed += OnMenuDisplayed;
        DebugMenu.OnHidden += OnMenuHidden;
    }

    public override void _ExitTree()
    {
        DebugMenu.OnDisplayed -= OnMenuDisplayed;
        DebugMenu.OnHidden -= OnMenuHidden;
    }

    private void OnMenuDisplayed()
    {
        if (IsInstanceValid(_displayButton))
        {
            _displayButton.Visible = false;
        }
    }

    private void OnMenuHidden()
    {
        if (IsInstanceValid(_displayButton))
        {
            _displayButton.Visible = true;
        }
    }
}
