// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Events

///<summary>
/// Contains events, triggered by various apps.
///</summary>
module Event =
    /// IO Events
    module IO =
        let output = new Event<string>()
        let error  = new Event<string>()

        /// Output event (Sysout from Kappa++ code)
        [<CLIEvent>]
        let Output = output.Publish

        /// Error event (Syserr from Kappa++ code)
        [<CLIEvent>]
        let ErrorOutput = error.Publish

    // App diagnostics events
    module Diagnostics =
        let info    = new Event<string>()
        let debug   = new Event<string>()
        let error   = new Event<string>()
        let success = new Event<string>()

        /// Info message
        [<CLIEvent>]
        let Info = info.Publish

        /// Debug message
        [<CLIEvent>]
        let Debug = debug.Publish

        /// Error message
        [<CLIEvent>]
        let Error= error.Publish

        /// Success message
        [<CLIEvent>]
        let Success = success.Publish

    // Event triggers
    module Triggers =
        let trigger(event:Event<_>) message =
            event.Trigger(message)

        let output(message)         = message |> trigger IO.output
        let errorOutput(message)    = message |> trigger IO.error
        
        let info(message)           = message |> trigger  Diagnostics.info
        let debug(message)          = message |> trigger  Diagnostics.debug
        let error(message)          = message |> trigger  Diagnostics.error
        let success(message)        = message |> trigger  Diagnostics.success