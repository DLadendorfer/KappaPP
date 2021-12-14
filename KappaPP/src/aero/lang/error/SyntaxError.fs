// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang.Error

///<summary>
/// This module contains syntax error exceptions. These are exceptions that can be thrown by the syntax validator.
///</summary>
module SyntaxError=
    open System
    type SyntaxErrorException(reason:string) =
        inherit Exception(reason)
