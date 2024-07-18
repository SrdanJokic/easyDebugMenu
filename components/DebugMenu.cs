// DebugMenu.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using System;

namespace EasyDebugMenu.Components;

public static class DebugMenu
{
    public static event Action OnDisplayed;
    public static event Action OnHidden;
    
    // TODO: Add alignment options
    public static void Display()
    {
        var layout = new HorizontalLayoutGroup();
        var horizontal = layout.CreateHorizontalLayoutGroup();
        horizontal.CreateButton("Title", null);
        
        OnDisplayed?.Invoke();
    }

    public static void Hide()
    {
        // TODO: Hide all elements
        OnHidden?.Invoke();
    }
}