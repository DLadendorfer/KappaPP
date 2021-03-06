// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Entry
module EntryTest =

    open NUnit.Framework
    open System.IO
    open Aero.Error.Errors
    open Aero.Entry.Entry

    let toVal o = LanguagePrimitives.EnumToValue o

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let test = 
        Assert.That(1, Is.EqualTo(1))
    [<Test>]
    let NoArgumentsTest () = 
        Assert.That(invoke [||], Is.EqualTo(toVal ExitCode.InvalidArgumentLength))

    [<Test>]
    let HelpTest () =
        Assert.That(invoke [|"-help"|], Is.EqualTo(toVal ExitCode.Success))

    [<Test>]
    let RunTestNoArgumentsTest () =
        Assert.That(invoke [|"-run"|], Is.EqualTo(toVal ExitCode.InvalidArgumentLength))

    [<Test>]
    let RunPathNotExistingTest () =
        Assert.That(invoke [|"-run"; @"C:\fakepath" |], Is.EqualTo(toVal ExitCode.InvalidArguments))

    [<Test>]
    let RunScriptTest () =
        let path = $"{System.Guid.NewGuid()}"
        if not (File.Exists path) then
            File.Delete "%temp%"
    
        use f = File.Create path
        f.Dispose()      

        Assert.That(invoke [|"-run"; path|], Is.EqualTo(toVal ExitCode.Success))
