// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Runtime
module Runtime =
    open System
    open System.Collections.Generic
    open Aero.Utils.ConsoleUtils
    open Aero.Runtime.Stack

    type Runtime() =
        let originId = 0xFFFF
        let origin = Stack(originId)

        let mutable activeStack = origin
        let mutable skipNextBlock = false
        let stacks = Dictionary<int, Stack>()

        member this.InitStack() =
            let id = activeStack.Pop()
            if not (stacks.ContainsKey(id)) then
                let stack = Stack(id)
                stacks.Add(id, stack)
                activeStack <- stack
            else
                activeStack <- stacks.[id]
        
        member this.Origin() =
            this.PushValue(originId)
            this.InitStack()

        member this.DeleteStack() =
            stacks.Remove(activeStack.Id) |> ignore 
            activeStack <- origin

        member this.DuplicateStack() =
            let id = activeStack.Pop()
            if stacks.ContainsKey(id) then raise (Exception())
            stacks.Add(id, activeStack.Clone(id))

        member this.PushValue(value) = 
            activeStack.Push(value)

        member this.Remove() =
            activeStack.Pop() |> ignore
            ()

        member this.Add() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a + b)

        member this.Subtract() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a - b)

        member this.Multiply() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a * b)

        member this.Divide() =
            let a, b = activeStack.BinaryPop()
            if b = 0 then raise(Exception())
            activeStack.Push(a / b)

        member this.Duplicate() = 
            let value = activeStack.Peek() 
            this.PushValue(value)

        member this.Concat() =
            let a, b = activeStack.BinaryPop()
            this.PushValue (int(string(a) + string(b)))

        member this.Greater() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a > b then 1 else 0)

        member this.Lower() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a < b then 1 else 0)

        member this.Equal() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a = b then 1 else 0)

        member this.SkipNextBlock(flag) =
            skipNextBlock <- flag

        member this.ShouldSkipNextBlock() =
            skipNextBlock
          
        member this.Condition(flag) =
            let b = activeStack.Peek()           
            skipNextBlock <- if flag then b = 0 else b > 0

        member this.Sysout() =
            activeStack.Pop()
            |> char 
            |> string
            |> output

        member this.Syserr() =
            activeStack.Pop()
            |> char 
            |> string
            |> error