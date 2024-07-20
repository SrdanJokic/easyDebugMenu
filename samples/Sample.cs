// Sample.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;
using Button = Godot.Button;

namespace EasyDebugMenu.Samples;

public partial class Sample : Node
{
    [Export] private Node _debugMenuRoot;
    
    private Button _displayButton;
    
    public override void _Ready()
    {
        CreateToggleButton();
        AssignGroups();
    }

    private void CreateToggleButton()
    {
        _displayButton = new Button();
        _displayButton.Text = "Show Easy Debug Menu";
        _displayButton.Pressed += () => DebugMenu.Display(_debugMenuRoot);
        AddChild(_displayButton);
    }

    private void AssignGroups()
    {
        DebugMenu.Add(new SampleGroup());
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
