// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang


module Literals =
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
    [<TestCase("VoteNay", 0)>]
    [<TestCase("VoteYea", 1)>]
    [<TestCase("TehePelo", 2)>]
    [<TestCase("TheIlluminati", 3)>]
    [<TestCase("SSSsss", 4)>]
    [<TestCase("TwitchUnity", 5)>]
    [<TestCase("UnSane", 6)>]
    [<TestCase("SabaPing", 7)>]
    [<TestCase("PoroSad", 8)>]
    [<TestCase("OhMyDog", 9)>]
    let LiteralTest (literal:string)(value) =
        let exitCode = runSource $"{literal} Kappa" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo(string(char value)))

