// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang

///<summary>
/// This module contains the lexer logic. The lexer is supposed to tokenize the source code.
/// The provided source code is passed in as an array. Each array element is checked if it is a token.
///</summary>
module Lexer =
    open Aero.Lang.Syntax
    open Aero.Events.Event.Triggers
    
    let nullToken = syntax.Head

    let splitSource (source:string) = 
        source.Split (splitChars())

    let tokenize (src:string array) =
        debug "Lexing tokens:"
        src
        |> Array.map (fun sourceToken -> sourceToken.ToLowerInvariant())
        |> Array.map (fun sourceToken -> 
            match syntax |> List.tryFind (fun s -> sourceToken = s.Raw) with
            | Some token -> token               
            | None       -> nullToken
        )
        |> Array.filter (fun t -> t.Token <> Token.None) 

