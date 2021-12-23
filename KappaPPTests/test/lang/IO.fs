// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang


module IO =
    open System
    open System.IO
    open NUnit.Framework
    open Aero.App.Runner
    open Aero.Error.Errors

    let mutable consoleOutput:StringWriter = null

    [<SetUp>]
    let Setup () =
        infoDumpEnabled <- false
        consoleOutput <- new StringWriter()
        Console.SetOut(consoleOutput)
        ()

    [<TearDown>]
    let TearDown () =
        consoleOutput.Dispose()

    [<Test>]
    let OutputTest () =
        let exitCode = runSource $"SabaPing SabaPing LUL Kappa" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo("M"))

    [<Test>]
    let OutputAllTest () =
        let exitCode = runSource $"SabaPing SabaPing LUL CoolCat KappaPride" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo("MM"))

    [<Test>]
    let ErrorOutputTest () =
        let exitCode = runSource $"SabaPing SabaPing LUL SwiftRage" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo("M"))

