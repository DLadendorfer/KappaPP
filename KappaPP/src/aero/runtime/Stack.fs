// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Runtime

///<summary>
/// This module contains the stack collection which are created and managed by the runtime.
///</summary>
module Stack = 
    open System.Linq
    open Aero.Utils.StdWrapper

    /// This is the primary data structure of the runtime which is used to store the pushed values.
    type Stack(id:int) =
        let content = SysStack<int>()

        member this.Id = id
        
        // due to the significance of this data structure each member provides info about the operation
        // S[1, 2] <= Stack with values 1 and 2
        // >> Push <= invocation of this.Push
        // =>S[1,2]<= Stack after the invocation

        /// Pushes the provided value onto the stack:
        /// S[1, 2] >> Push 3 => S[1, 2, 3]
        member this.Push value = 
            content.Push(value)
        
        /// Pops the top element form the stack and returns it:
        /// S[1, 2] >> Pop => S[1] returned 2
        member this.Pop () = 
            content.Pop()

        /// Pops the stack twice and returns it as a tuple (second top most, top most):
        /// S[1, 2, 3] >> BinaryPop => S[1] returned (2, 3)
        member this.BinaryPop () =
            let b = content.Pop()
            let a = content.Pop()
            (a, b)

        /// Peeks the stack and returns the value:
        /// S[1, 2] >> Peek => S[1, 2] returned 2
        member this.Peek () = 
            content.Peek()

        /// Peeks the stack twice and returns it as a tuple (second top most, top most):
        /// S[1, 2, 3] >> BinaryPeek => S[1, 2, 3] returned (2, 3)
        member this.BinaryPeek() =
            let b = content.Peek()
            let a = content.Skip(1).First()
            (a, b)

        /// Returns the stack count (number of elements on the stack):
        /// S[1, 1, 2] >> Count => S[1, 1, 2] returned 3
        member this.Count () =
            content.Count

        /// Exposes the internal data structure. Should only be used for unit tests!
        member this.Stack() = content

        /// Clones the stack and gives it the provided id:
        /// S[1, 2, 3]::id(1) >> Clone 2 => S[1, 2, 3]::id(1) returned S2[1, 2, 3]::id(2)
        member this.Clone id = 
            let clone = Stack(id) 
            let stack = new SysList<int>(content)
            stack.Reverse()
            for value in stack do
                clone.Push(value)
            clone



