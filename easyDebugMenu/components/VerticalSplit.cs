// VerticalSplit.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;

namespace EasyDebugMenu.Components;

public class VerticalSplit : Split<VSplitContainer>
{
    protected override Control.LayoutPreset OneOrNoChildrenPreset => Control.LayoutPreset.TopWide;
    protected override Control.LayoutPreset TwoChildrenPreset => Control.LayoutPreset.FullRect;

    public VerticalSplit()
    {
        Delegate = new VSplitContainer();
    }
}