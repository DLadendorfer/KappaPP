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
        let source = "TbAngel VoteYea djfkl ;::: d :LUL:"
        Assert.That(runSource source, Is.EqualTo(0))

