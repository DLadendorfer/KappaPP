// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.App

///<summary>
/// Command line interface for continous Kappa++ tests.
///</summary>
module Cli =
    open Aero.Events.Event.IO
    open Aero.Events.Event.Diagnostics
    open Aero.Events.Event.Triggers
    open Aero.Error.Errors
    open Aero.Runtime.Runtime
    open Aero.Lang.Lexer
    open Aero.Lang.Interpreter
    open Aero.Utils.Constants.Application
    open Aero.Utils.Constants.Language
    open Aero.Utils

    type CliPrefixHandler() =
        let mutable sendFirstMessage = true
        let mutable sendLastMessage = false
        
        member this.SendLastMessage() =
            sendLastMessage <- true

        member this.Print() =
            System.Console.Write(" ")
            System.Console.ForegroundColor <- System.ConsoleColor.Red

            if sendFirstMessage then
               System.Console.Write("\r╔")
               sendFirstMessage <- false
            else if sendLastMessage then
               System.Console.Write("\r╚")
            else            
               System.Console.Write("\r╠")
            
            System.Console.ResetColor()            
            System.Console.Write(" ")    
    
    let prefixHandler = CliPrefixHandler()

    let setupHandlers() =
        BeforeInput.Add   (fun _ -> prefixHandler.Print(); System.Console.ForegroundColor <- ConsoleUtils.debugColor)
        Output.Add        (fun msg -> if not(msg = "") then ConsoleUtils.success($"{msg}"))
        ErrorOutput.Add   (fun msg -> if not(msg = "") then ConsoleUtils.error($"{msg}"))
        Prefix.Add        (fun msg -> prefixHandler.Print())        
        Info.Add          (fun msg -> ConsoleUtils.info(msg))
        Error.Add         (fun msg -> ConsoleUtils.error(msg))

    let handleInput (runtime:Runtime) (input:string) =
        input
        |> splitSource
        |> tokenize
        |> interprete runtime

    let cliLoop() =
        let mutable inputProvided = true
        let runtime = Runtime()

        while inputProvided do    
            beforeInput()
            let input = ConsoleUtils.readLine()

            match input with
            | "" -> inputProvided <- false
            | _ -> handleInput runtime input
        

    /// Displays uses of the executable.
    let cli () = 
        setupHandlers()
        error "\b══════════ K++ CLI Runtime ══════════════════════════════"
        info $"{appName} :: lang = {langVersion}"
        info "Enter K++ source lines to invoke them. Enter nothing to exit."
        cliLoop()
        prefixHandler.SendLastMessage()
        error "\b══════════ K++ Finish ═══════════════════════════════════"
        ExitCode.Success |> toExitValue


