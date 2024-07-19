// HorizontalLayoutGroup.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;

namespace EasyDebugMenu.Components;

public class HorizontalLayout : Layout<VFlowContainer>
{
    internal HorizontalLayout()
    {
        Delegate = new VFlowContainer();
    }
    
    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
}