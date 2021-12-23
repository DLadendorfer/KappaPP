// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang


module Stacks =
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
    [<TestCase("TBAngel")>]
    [<TestCase("PogChamp")>]
    [<TestCase("ThankEgg")>]
    [<TestCase("CopyThis")>]
    let StackOperatorTest (operator:string) =
        let exitCode = runSource $"VoteYea {operator} VoteYea {operator}" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))

    [<Test>]
    [<TestCase("CoolCat", 7)>]
    [<TestCase("FBBlock", 0)>]
    let UnaryTest (operator:string)(value:int) =
        let exitCode = runSource $"SabaPing {operator} Kappa" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo(string(char value)))

    [<Test>]
    [<TestCase("VoteYea", "VoteNay", "PowerUpL", 0)>]
    [<TestCase("VoteNay", "VoteNay", "PowerUpL", 0)>]
    [<TestCase("VoteYea", "VoteYea", "PowerUpL", 0)>]
    [<TestCase("VoteNay", "VoteYea", "PowerUpL", 1)>]
    [<TestCase("VoteYea", "VoteNay", "PowerUpR", 1)>]
    [<TestCase("VoteNay", "VoteNay", "PowerUpR", 0)>]
    [<TestCase("VoteYea", "VoteYea", "PowerUpR", 0)>]
    [<TestCase("VoteNay", "VoteYea", "PowerUpR", 0)>]
    [<TestCase("VoteYea", "VoteNay", "TwitchVotes", 0)>]
    [<TestCase("VoteNay", "VoteNay", "TwitchVotes", 1)>]
    [<TestCase("VoteYea", "VoteYea", "TwitchVotes", 1)>]
    [<TestCase("VoteNay", "VoteYea", "TwitchVotes", 0)>]
    let ConditionalTest (var1:string)(var2:string)(operator:string)(value:int) =
        let exitCode = runSource $"{var1} {var2} {operator} Kappa" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo(string(char value)))



    [<Test>]
    let DivideByZero() =
        let exitCode = runSource $"SabaPing VoteNay MorphinTime Kappa" 

        Assert.That(exitCode, Is.EqualTo(toExitValue(ExitCode.Success)))
        Assert.That(consoleOutput.ToString(), Is.EqualTo(string(char 0)))


