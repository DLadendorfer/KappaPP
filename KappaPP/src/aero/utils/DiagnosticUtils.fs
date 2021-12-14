// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Utils

module DiagnosticUtils =
    open System.Diagnostics

    let startTimer () = 
        let stopwatch = new Stopwatch()
        stopwatch.Start()
        stopwatch

    let stopTimer (stopwatch:Stopwatch) = 
        stopwatch.Stop()
        stopwatch