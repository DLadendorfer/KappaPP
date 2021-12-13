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