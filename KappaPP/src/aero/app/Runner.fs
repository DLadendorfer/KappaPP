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
    open Aero.Utils.DiagnosticUtils
      

    let runSource (src:string) =
        let stopwatch = startTimer
        info $"Running source:\n{src}\n"
        let tokens = src
                     |> fun s -> s.Split [| ' '; '\t'; ':'; |]
                     |> tokenize
        tokens |> Array.iter tokenInfo
        validateSyntax tokens
        interprete tokens

        //success $"\nFinished source run in {(stopTimer stopwatch).ElapsedMilliseconds}ms"
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
            
                   
        