namespace Aero.Lang.Error
module SyntaxError=
    open System
    type SyntaxErrorException(reason:string) =
        inherit Exception(reason)
