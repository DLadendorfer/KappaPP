// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.App

///<summary>
/// The "runner" is an umbrella term that encapsulates the lexer, a syntax validator and the interpreter.
/// For the language details check ../lang/Syntax.fs. Alternatively check the documentation in the project root.
///</summary>
module Runner =
    open System.IO
    open Aero.Lang.Interpreter
    open Aero.Error.Errors
    open Aero.Lang.Syntax
    open Aero.Lang.Lexer
    open Aero.Lang.SyntaxValidator
    open Aero.Utils.ConsoleUtils
    
    let debugTokens (tokens) =
        tokens |> Array.iter tokenInfo
        tokens

    let runSource (src:string) =
        info $"Source:\n{src}\n"
        src
        |> fun s -> s.Split (splitChars())
        |> tokenize
        |> debugTokens
        |> validateSyntax
        |> interprete

        ExitCode.Success |> toExitValue

    let runScript (path:string) =
        if not (File.Exists path) then 
            error "File does not exist"            
            ExitCode.InvalidArguments |> toExitValue
        else 
            // concat content of file to form the source code
            File.ReadAllLines(path) 
            |> String.concat(" ")
            |> runSource
            
                   
        