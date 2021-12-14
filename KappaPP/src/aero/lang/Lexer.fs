// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang

module Lexer =
    open Aero.Lang.Syntax
    open Aero.Utils.ConsoleUtils
    
    let tokenize (src:string array) =
        debug "Lexing tokens:"
        src
        |> Array.map (fun sourceToken -> sourceToken.ToLowerInvariant())
        |> Array.map (fun sourceToken -> 
            match syntax |> List.tryFind (fun s -> sourceToken = s.Raw) with
            | Some t -> t               
            | None   -> syntax.Head // null token is head
        )
        |> Array.filter (fun t -> t.Token <> Token.None) 

