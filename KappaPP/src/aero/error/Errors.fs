// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Error

///<summary>
/// Error module. This module does not include the language based errors (neither compile time nor runtime errors).
/// 
/// Errors defined in this module and their respective functions are used to inform the app-invoker about faulty program
/// execution.
///</summary>
module Errors =
    
    // program exit codes (passed to main)
    type ExitCode = 
        | Success = 0
        | InvalidArgumentLength = 1
        | InvalidArguments = 2

    let toExitValue (exitCode:ExitCode) = LanguagePrimitives.EnumToValue exitCode
