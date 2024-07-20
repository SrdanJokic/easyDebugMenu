// SampleGroup.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using EasyDebugMenu.Components;

namespace EasyDebugMenu.Samples;

public class SampleGroup : Group
{
    public override Button CreateToggleButton()
    {
        return new Button("Sample Group Button", null);
    }
}