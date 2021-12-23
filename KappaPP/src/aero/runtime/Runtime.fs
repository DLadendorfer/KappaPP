// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Runtime

///<summary>
/// This module contains the runtime type which is the runtime instance (the mutable state) that the interpreter
/// invokes based on the tokenized source code.
///</summary>
module Runtime =
    open System
    open Aero.Utils.StdWrapper
    open Aero.Events.Event.Triggers
    open Aero.Runtime.Stack

    /// The mutable Kappa++ state wrapper.
    type Runtime() =        

        // ORIGIN STACK
        // The origin stack is the base stack that the runtime will always have.
        // The intention of this stack is to be able to create other stacks, though it is possible to push onto it and
        // manipulate it's values just like any other stack.
        // 'Clean' Kappa++ code always starts by defining other stacks. The invocation of [stack_origin] is useless but 
        // indicates the intent:
        //
        //      TBAngel              .[stack_origin]
        //      VoteYea PogChamp     .1 .[stack_init] 
        //          <Kappa++ code>   anything you want
        //      VoteYeah ThankEgg    .1 .[stack_destroy]
        //

        // Origin stack has ID 0xFFFF. This ID is reserved.
        let originId = 0xFFFF
        let origin = Stack(originId)
        
        // all current stacks
        let stacks = SysDict<int, Stack>()
        // the currently pushable, popable stack
        let mutable activeStack = origin 

        let mutable skipNextBlock = false

        /// Initializes or activates the stack with the ID of the active stacks value
        member this.InitStack() =
            let id = activeStack.Pop()
            if not (stacks.ContainsKey(id)) then
                let stack = Stack(id)
                stacks.Add(id, stack)
                activeStack <- stack
            else
                activeStack <- stacks.[id]
        
        /// Sets the active stack to ORIGIN
        member this.Origin() =
            this.PushValue(originId)
            this.InitStack()

        /// Deletes the active stack
        member this.DeleteStack() =
            stacks.Remove(activeStack.Id) |> ignore 
            activeStack <- origin

        /// Duplicates the current stack. The id of the new stack is the top value of the active stack, which will be popped
        member this.DuplicateStack() =
            let id = activeStack.Pop()
            if not(stacks.ContainsKey(id)) then
                stacks.Add(id, activeStack.Clone(id))

        /// Pushes the given value onto the active stack
        member this.PushValue(value) = 
            activeStack.Push(value)

        /// Pops and ignores the top value of the stack
        member this.Remove() =
            activeStack.Pop() |> ignore
            ()

        /// Adds the two top values of the stack
        member this.Add() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a + b)

        /// Subtracts the two top values of the stack
        member this.Subtract() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a - b)

        /// Multiplies the two top values of the stack
        member this.Multiply() =
            let a, b = activeStack.BinaryPop()
            activeStack.Push(a * b)

        /// Divides the two top values of the stack
        member this.Divide() =
            let a, b = activeStack.BinaryPop()
            if b = 0 then activeStack.Push(0) else activeStack.Push(a / b)

        /// Duplicates the stacks top value (the top value is not popped)
        member this.Duplicate() = 
            let value = activeStack.Peek() 
            this.PushValue(value)

        /// Concats the top two values of the stack. e.g.: S[1, 2] >> Concat => S[12]
        member this.Concat() =
            let a, b = activeStack.BinaryPop()
            this.PushValue (int(string(a) + string(b)))

        /// Invokes a GreaterThan boolean comparison between the two top values of the stack and pushes the result
        member this.Greater() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a > b then 1 else 0)
            
        /// Invokes a LowerThan boolean comparison between the two top values of the stack and pushes the result
        member this.Lower() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a < b then 1 else 0)
            
        /// Invokes an Equals boolean comparison between the two top values of the stack and pushes the result
        member this.Equal() =
            let a, b = activeStack.BinaryPeek()
            this.PushValue(if a = b then 1 else 0)

        /// Mutate the skipNextBlock flag
        member this.SkipNextBlock(flag) =
            skipNextBlock <- flag

        /// Value of the mutable next block flag
        member this.ShouldSkipNextBlock() =
            skipNextBlock
          
        /// Mutates skipNextBlock based on the top stack value and the flag value
        member this.Condition(flag) =
            let b = activeStack.Peek()           
            skipNextBlock <- if flag then b = 0 else b > 0

        /// Pops and outputs the top value of the stack
        member this.Sysout() =
            activeStack.Pop()
            |> char 
            |> string
            |> output

        /// Pops and outputs all values of the stack
        member this.SysoutAll() =
            while activeStack.Count() > 0 do this.Sysout()

        /// Pops and error-outputs the top value of the stack
        member this.Syserr() =
            activeStack.Pop()
            |> char 
            |> string
            |> errorOutput