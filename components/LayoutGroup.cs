using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EasyDebugMenu.Components;

[SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
public abstract partial class LayoutGroup : DebugElement
{
    private readonly List<DebugElement> Elements = new();

    internal LayoutGroup() { } 

    public virtual Button CreateButton(string title, Action onClick, bool enabled = true)
    {
        var button = new Button(title, onClick, enabled);

        AddChild(button);
        Elements.Add(button);
        return button;
    }

    public abstract void Clear();
}