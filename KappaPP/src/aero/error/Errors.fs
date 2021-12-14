// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Error

module Errors =
    
    type ExitCode = 
        | Success = 0
        | InvalidArgumentLength = 1
        | InvalidArguments = 2

    let toExitValue (exitCode:ExitCode) = LanguagePrimitives.EnumToValue exitCode
