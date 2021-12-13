namespace Aero.Error

module Errors =
    
    type ExitCode = 
        | Success = 0
        | InvalidArgumentLength = 1
        | InvalidArguments = 2

    let toExitValue (exitCode:ExitCode) = LanguagePrimitives.EnumToValue exitCode
