namespace Aero.Utils
module ConsoleUtilsTest =

    open NUnit.Framework
    open Aero.Utils.ConsoleUtils


    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let LogTextTest () =
        Assert.That(info("test"), Is.EqualTo(()))
        Assert.That(debug("test"), Is.EqualTo(()))
        Assert.That(error("test"), Is.EqualTo(()))
        Assert.That(success("test"), Is.EqualTo(()))

