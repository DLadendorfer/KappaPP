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
    open Aero.Events.Event.IO
    open Aero.Events.Event.Diagnostics
    open Aero.Events.Event.Triggers
    open Aero.Lang.Interpreter
    open Aero.Error.Errors
    open Aero.Lang.Lexer
    open Aero.Runtime.Runtime
    open Aero.Utils.Constants.Application
    open Aero.Utils.Constants.Language
    open Aero.Utils
    
    let mutable infoDumpEnabled = true // for unit tests
    let mutable handlersInitialized = false

    let setupHandlers () =
        if not(handlersInitialized) then
            // delegate diagnostic message to Console
            Info.Add    (fun msg -> ConsoleUtils.info msg)
            Debug.Add   (fun msg -> ConsoleUtils.debug msg)
            Error.Add   (fun msg -> ConsoleUtils.error msg)
            Success.Add (fun msg -> ConsoleUtils.success msg)
    
            // delegate sysout to Console
            Output.Add        (fun msg -> ConsoleUtils.output msg)
            ErrorOutput.Add   (fun msg -> ConsoleUtils.outputError msg)

            handlersInitialized <- true

    let runSource (src:string) =
        if (infoDumpEnabled) then
            info $"{appName} :: lang = {langVersion}"
        setupHandlers()
        src
        |> splitSource
        |> tokenize
        |> interprete (Runtime())

        ExitCode.Success |> toExitValue

    let runScript (path:string) =
        setupHandlers()
        if not (File.Exists path) then 
            error "File does not exist"            
            ExitCode.InvalidArguments |> toExitValue
        else 
            // concat content of file to form the source code
            File.ReadAllLines(path) 
            |> String.concat(" ")
            |> runSource
            
                   
        