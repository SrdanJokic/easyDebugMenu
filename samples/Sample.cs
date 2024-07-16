using Godot;
using System;
using EasyDebugMenu.Components;

namespace EasyDebugMenu.Samples;

public partial class Sample : Node
{
    public override void _Ready()
    {
        DebugMenu.Display();
    }
}
