// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Entry

open Aero.Utils.ConsoleUtils
open Aero.Error.Errors
open Aero.App.Runner

///<summary>
/// Invokes the correct procedures based on the given command line args.
///</summary>
module Entry =
    let help () = 
        info "Execute a source file with -run <pathToFile>"
        ExitCode.Success |> toExitValue

    let run (argv:string array) =
        match argv.Length with
        | 2 ->
            let path = argv.[1]
            debug $"Executing {path}"
            runScript path
        | _ ->
            error "Too many arguments provided. Run with -help for help." 
            ExitCode.InvalidArgumentLength |> toExitValue

    let invokeApp (argv:string array) : int = 
        match argv.[0] with
        | "-help" -> help ()
        | "-run" -> run argv
        | _ -> 
            error "Unknown argument. Run with -help for help."
            ExitCode.InvalidArguments |> toExitValue

    let invoke (argv:string array) =
        match argv.Length with
        | 0 ->
            error "Arguments must be provided. Run with -help for help." 
            ExitCode.InvalidArgumentLength |> toExitValue
        | _ -> invokeApp argv
    

