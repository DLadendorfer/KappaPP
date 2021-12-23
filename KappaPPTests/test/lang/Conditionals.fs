// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang


module Conditionals =
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
    [<TestCase("VoteYea", "EleGiggle", "", 7)>]
    [<TestCase("VoteNay", "EleGiggle", "", 0)>]
    [<TestCase("VoteYea", "Jebaited", "", 0)>]
    [<TestCase("VoteNay", "Jebaited", "", 7)>]
    [<TestCase("VoteYea", "EleGiggle", "SSSsss", 7)>]
    [<TestCase("VoteNay", "EleGiggle", "SSSsss", 0)>]
    [<TestCase("VoteYea", "Jebaited", "SSSsss", 0)>]
    [<TestCase("VoteNay", "Jebaited", "SSSsss", 7)>]
    let ConditionalTest (testValue:string) (operator:string) (intermediate:string) (value:int) =
        let exitCode = runSource $"{testValue} {operator} {intermediate} GivePLZ SabaPing Kappa TakeNRG" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))

        if value = 0 then
            Assert.That(consoleOutput.ToString().Length, Is.EqualTo(0))
        else
            Assert.That(consoleOutput.ToString(), Is.EqualTo(string(char value)))
