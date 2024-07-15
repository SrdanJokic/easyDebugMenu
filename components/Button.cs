using System;

namespace EasyDebugMenu.Components;

public partial class Button : DebugElement
{
    private string _title;
    private Action _onClick;
    private bool _enabled;
    
    internal Button(string title, Action onClick, bool enabled = true)
    {
        _title = title;
        _onClick = onClick;
        _enabled = enabled;
    }

    public override void ReDraw()
    {
        throw new System.NotImplementedException();
    }
}