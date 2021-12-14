// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Error
module ErrorsTest = 
    open NUnit.Framework
    open Aero.Error.Errors


    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let ConvertToSuccessTest () =
        Assert.That(toExitValue ExitCode.Success, Is.EqualTo(0))

    [<Test>]
    let ConvertToInvalidArgumentsTest () =
        Assert.That(toExitValue ExitCode.InvalidArguments, Is.EqualTo(2))

    [<Test>]
    let ConvertToInvalidArgumentLengthTest () =
        Assert.That(toExitValue ExitCode.InvalidArgumentLength, Is.EqualTo(1))
