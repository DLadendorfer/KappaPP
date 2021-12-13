namespace Aero.Lang
module Interpreter =
    open System
    open Aero.Lang.Syntax
    open Aero.Runtime.Runtime
    
    
    let interpreteOperator (token:TokenInfo) (runtime:Runtime) = 
        match token with
        | t when t.CompileUnit = CompileUnit.OpConcat -> runtime.Concat()
        | t when t.CompileUnit = CompileUnit.OpDuplicate -> runtime.Duplicate()
        | t when t.CompileUnit = CompileUnit.OpAdd -> runtime.Add()
        | t when t.CompileUnit = CompileUnit.OpSubtract -> runtime.Subtract()
        | t when t.CompileUnit = CompileUnit.OpMultiply -> runtime.Multiply()
        | t when t.CompileUnit = CompileUnit.OpDivide -> runtime.Divide()
        | _ -> raise (NotImplementedException())

    let interpreteIO (token:TokenInfo) (runtime:Runtime) = 
        match token with
        | t when t.CompileUnit = CompileUnit.IoSysout -> runtime.Sysout()
        | t when t.CompileUnit = CompileUnit.IoSyserr -> runtime.Syserr()
        | _ -> raise (NotImplementedException())

    let interpreteStack (token:TokenInfo) (runtime:Runtime) =
        match token with 
        | t when t.CompileUnit = CompileUnit.StackOrigin -> runtime.Origin()
        | t when t.CompileUnit = CompileUnit.StackInit -> runtime.InitStack()
        | t when t.CompileUnit = CompileUnit.StackDestroy -> runtime.DeleteStack()
        | t when t.CompileUnit = CompileUnit.StackDuplicate -> runtime.DuplicateStack()
        | _ -> raise (NotImplementedException())

    let interpreteRegion (token:TokenInfo) (runtime:Runtime) =
        match token with
        | t when t.CompileUnit = CompileUnit.BlockOrigin -> runtime.ShouldSkipNextBlock()
        | t when t.CompileUnit = CompileUnit.BlockEnd -> runtime.ShouldSkipNextBlock()
        | _ -> raise (NotImplementedException())

    let interpreteControlFlow (token:TokenInfo) (runtime:Runtime) =
        match token with
        | t when t.CompileUnit = CompileUnit.CfIf -> runtime.Condition(true)
        | t when t.CompileUnit = CompileUnit.CfElse -> runtime.Condition(false)
        | _ -> raise (NotImplementedException())

    let interprete (tokens:TokenInfo array) =
        let runtime = Runtime()
        let mutable skipBlock = false

        for token in tokens do
            if not(skipBlock) then            
                match token.Value with
                | Literal num -> runtime.PushValue(num)
                | Operator op -> interpreteOperator token runtime
                | IO io -> interpreteIO token runtime
                | Stack stack -> interpreteStack token runtime
                | Region region -> skipBlock <- interpreteRegion token runtime
                | CF controlFlow -> interpreteControlFlow token runtime
                | _ -> ()
            else if token.CompileUnit = CompileUnit.BlockEnd then
                runtime.SkipNextBlock(false)
                skipBlock <- false
                
            

