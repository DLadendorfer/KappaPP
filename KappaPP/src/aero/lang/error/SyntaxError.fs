// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Lang.Error
module SyntaxError=
    open System
    type SyntaxErrorException(reason:string) =
        inherit Exception(reason)
