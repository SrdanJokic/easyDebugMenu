// Group.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

namespace EasyDebugMenu.Components;

public abstract class Group
{
    public abstract Button GetToggleButton();

    // TODO: Create a method that takes in a full screen panel element and then each admin can override it as they want
    //  The buttons should be auto-created based on the public parameters from here and should invoke the method above
    //  which shows or hides the full screen panel on toggle
    
    // TODO: Also add group "connections" which connect a group to a DebugMenu with a builder pattern. Something like:
    //  var debugMenuConfig = new DebugMenuConfigBuilder(menuParent)
    //    .WithGroup<DevGroup1>();
    //    .WithGroup<DevGroup2>();
    //    .Build();
    //  DebugMenu.Show(debugMenuConfig);

    // TODO: A group is a generic abstract element that can be inherited by others
    //  The idea is to have each group define a "title" which will be shown either on the left or the right
    //  and then implement a set of controls on it's own, however it wants. It's going to receive a 
    //  an argument to the layout (either horizontal or vertical) in a function and it can use it to build
    //  controls within itself however it wants. Developers should ideally define their own groups and logic
    //  that goes into them. Keep in mind that developers should also be able to not use groups at all and just
    //  define elements in the layouts directly, if that is what's wished. Also consider if groups can be nested
    //  (probably not, as it gets complicated when dealing with UI nesting, but whatever)
}