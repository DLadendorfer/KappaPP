namespace Aero.Runtime

module Stack = 
    open System.Collections.Generic
    open Aero.Utils.ConsoleUtils

    type Stack(id:int) =
        let content = Stack<int>()
        member this.Id = id
        member this.Push value = 
            content.Push(value)
        member this.Pop () = 
            content.Pop()
        member this.Peek () = 
            content.Peek()
        member this.Count () =
            content.Count
        member this.Stack() = content
        member this.Clone id = 
            let clone = Stack(id) 
            let stack = new List<int>(content)
            stack.Reverse()
            for value in stack do
                clone.Push(value)
            clone
        member this.Dump () =
            debug $"Stack [id={id}]: {content}"


