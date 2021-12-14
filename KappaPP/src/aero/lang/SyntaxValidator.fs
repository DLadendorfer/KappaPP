// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang
module SyntaxValidator =
    open Aero.Lang.Error.SyntaxError
    open Aero.Lang.Syntax
    open Aero.Utils.ConsoleUtils

    let validateConditional cfif tokens =
        // todo
        ()

    let validateBlock blockOrigin tokens =
        // todo
        ()

    let validateSyntax (tokens:TokenInfo array) =
        try
            ()
            //for token in tokens do
            //   match token with
            //   | t when t.CompileUnit = CompileUnit.None -> () // something that does not exist is always valid
            //   | t when (t.Value.GetType() = TokenValue.Stack.GetType()) -> () // stack operations are always valid
            //   | t when (t.Value.GetType() = TokenValue.Literal.GetType()) -> () // number literals can always be put onto an active stack
            //   | t when t.CompileUnit = CompileUnit.BlockOrigin -> validateBlock t tokens
            //   | t when t.CompileUnit = CompileUnit.BlockEnd -> () // block ends are checked with block origin checks
            //   | t when (t.Value.GetType() = TokenValue.IO.GetType()) -> () // io commands are alaways valid
            //   | t when t.CompileUnit = CompileUnit.CfIf -> validateConditional t tokens
            //   | t when t.CompileUnit = CompileUnit.CfThen || t.CompileUnit = CompileUnit.CfElse -> () // checked by conditional check (cfif)
            //   | t when (t.Value.GetType() = TokenValue.Operator.GetType()) -> () // operators can always be invoked
            //   | _ -> raise(SyntaxErrorException($"Unknown token: {token}"))
               
        with
        | :? SyntaxErrorException as err -> error err.Message

