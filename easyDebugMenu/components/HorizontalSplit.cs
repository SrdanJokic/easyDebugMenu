// HorizontalSplit.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;

namespace EasyDebugMenu.Components;

public class HorizontalSplit : Split<HSplitContainer>
{
    public HorizontalSplit(Control.LayoutPreset preset = Control.LayoutPreset.FullRect)
    {
        Delegate = new HSplitContainer();
        Delegate.SetAnchorsPreset(preset);
    }
}