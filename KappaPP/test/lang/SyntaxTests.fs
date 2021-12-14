// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang
module SyntaxTests =
    open NUnit.Framework
    open Aero.Lang.Syntax

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let TokenInfoTest () =
        syntax 
        |> List.iter (fun token -> Assert.That(tokenInfo token, Is.EqualTo(())))
