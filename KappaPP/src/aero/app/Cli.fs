﻿// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.App

///<summary>
/// Command line interface for continous Kappa++ tests.
///</summary>
module Cli =
    open Aero.Events.Event.Diagnostics
    open Aero.Events.Event.Triggers
    open Aero.Error.Errors
    open Aero.Utils

    let setupHandlers() =
        Info.Add    (fun msg -> ConsoleUtils.info msg)

    /// Displays uses of the executable.
    let cli () = 
        setupHandlers()
        //info "Execute a source file with -run <pathToFile>"
        ExitCode.Success |> toExitValue

