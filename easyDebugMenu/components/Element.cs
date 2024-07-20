// Element.cs
// 
// This script is licensed under the MIT License.
// See the LICENSE file in the root of the repository for more details.
// 
// Copyright (c) 2024 Srdan Jokic

using Godot;
using System;

namespace EasyDebugMenu.Components;

public abstract class Element<T> where T : Node
{
    public T Delegate { get; protected set; }
}
