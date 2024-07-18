// HorizontalLayoutGroup.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;

namespace EasyDebugMenu.Components;

public partial class HorizontalLayoutGroup : LayoutGroup
{
    private VFlowContainer _flowContainer;
    
    internal HorizontalLayoutGroup()
    {
        _flowContainer = new VFlowContainer();
    }
    
    public override void ReDraw()
    {
        throw new System.NotImplementedException();
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
}