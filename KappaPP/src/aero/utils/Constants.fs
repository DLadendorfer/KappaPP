// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------

namespace Aero.Utils

///<summary>
///Holds some global constants.
///</summary>
module Constants =
    /// Application constants
    module Application =
        let appName = System.AppDomain.CurrentDomain.FriendlyName
        let appNameShort = "K++"

    /// Language constants
    module Language =
        open Application
        let langMajor = 1
        let langMinor = 0
        let langPatch = 0
        let langVersion = $"{appNameShort} (V::{langMajor}.{langMinor}.{langPatch})"


