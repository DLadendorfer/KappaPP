// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Utils

///<summary>
/// Contains discriminated unions for the standard library which may have conflicting names with Kappa++ features.
///</summary>
module StdWrapper =
    // create discriminated unions for the System.Collections.Generic datatypes to minimize naming confusion
    type SysStack<'a> = System.Collections.Generic.Stack<'a>
    type SysList<'a> = System.Collections.Generic.List<'a>
    type SysDict<'a, 'b> = System.Collections.Generic.Dictionary<'a, 'b>

