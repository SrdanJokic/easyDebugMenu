# easyDebugMenu

An easily-extensible generic on-screen in-game debug menu for C#.

## Installation

Godot only supports marking editor plugins as "plugins" unfortunately. For this reason, feel free to simply include the EasyPool/Scripts in your project folder.

## Quick Start

```csharp
using EasyDebugMenu;
using EasyDebugMenu.Components;

class SampleGroup : Group
{
    // Implement the behaviour of your group here
}

class AnotherSampleGroup : Group
{
    // Implement the behaviour of your group here
}

class Sample : Node
{
    public override _Ready()
    {
        // Assign your group(s)
        DebugMenu.Add(new SampleGroup());
        
        // Display the debug menu as a child of the sample node
        DebugMenu.Display(this);
        
        // Groups can be added and removed dynamically during display as well
        var anotherGroup = new AnotherSampleGroup();
        DebugMenu.Add(anotherGroup);
        DebugMenu.Remove(anotherGroup);
    }
}
```

The list of currently-available controls. Keep in mind that only the `Layout` elements can create and assign other elements:

| Element           | Description                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| Vertical Layout   | Wrapper for `Godot.VBoxContainer`. Maintains a vertical list of elements.   |
| Horizontal Layout | Wrapper for `Godot.HBoxContainer`. Maintains a horizontal list of elements. |
| Button            | Wrapper for `Godot.Button`. Invokes an "Action" when pressed.               |

## How To

The idea behind using the `EasyDebugMenu` is to implement your own so-called `Groups` and then assign them to the menu which displays them. By implementing a `Group` you provide a `Button` (rendered on the side) which will display a larger menu of all elements available to you, depending on how you implemented a group.

Sample code:

```csharp
// TODO Code that only implements the button and does not add any elements
```

In-game:

<!--TODO-->
![Screenshot of a displayed debug menu with no options on the side, just a button on the left]()

The code above only adds a button but does not implement any meaningful logic. To change that, we can use the `OnDraw` method and use the provided `Layout` to create our elements.

Sample code:

```csharp
// TODO: Really simple code for displaying some labels, input buttons, whatever
```

In-game:

<!--TODO-->
![Screenshot of a displayed debug menu with some options on the right now]()
