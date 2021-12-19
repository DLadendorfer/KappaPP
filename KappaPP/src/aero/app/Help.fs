// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.App

///<summary>
/// Help application.
///</summary>
module Help =
    open Aero.Events.Event.Diagnostics
    open Aero.Events.Event.Triggers
    open Aero.Error.Errors
    open Aero.Utils

    let setupHandlers() =
        Info.Add    (fun msg -> ConsoleUtils.info msg)
        Debug.Add   (fun msg -> ConsoleUtils.debug $"\t|> KappaPP.exe {msg}")

    /// Displays uses of the executable.
    let help () = 
        setupHandlers()
        info "The following apps can be started: Runner (-run), CLI (-cli), Help (-help):"
        info "Execute Kappa++ code in an interactive CLI with -cli"
        debug "-cli"
        info "Execute a source file with -run <pathToFile>"
        debug "-run \"<path>\""
        info "Get this help with -help."
        debug "-help"
        ExitCode.Success |> toExitValue

