using Godot;
using System;

namespace EasyDebugMenu.Components;

public abstract partial class DebugElement : Node
{
    public abstract void ReDraw();
}
