// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang
module StackTests =
    open NUnit.Framework
    open System.Collections.Generic
    open Aero.Runtime.Stack

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let EmptyStackTest () =
        let expected = new Stack<int>()
        let stack = Stack(1)
        Assert.That(stack.Stack(), Is.EqualTo(expected))

    [<Test>]
    let PushStackTest () =
        let expected = new Stack<int>([1; 2; 3])
        let stack = Stack(1)
        [1; 2; 3] |> List.iter stack.Push
        Assert.That(stack.Stack(), Is.EqualTo(expected))

    [<Test>]
    let PopStackTest () =
        let expected = new Stack<int>([1])
        let stack = Stack(1)
        [1; 2] |> List.iter stack.Push
        let popped = stack.Pop()
        Assert.That(popped, Is.EqualTo(2))
        Assert.That(stack.Stack(), Is.EqualTo(expected))
