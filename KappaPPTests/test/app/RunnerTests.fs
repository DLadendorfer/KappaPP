// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.App
module RunnerTests =
    open NUnit.Framework
    open Aero.App.Runner

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let EmptySrcTest () = 
        Assert.That(runSource "", Is.EqualTo(0))

    [<Test>]
    let RunMinimumSourceTest () =
        let source = "TbAngel"
        Assert.That(runSource source, Is.EqualTo(0))

