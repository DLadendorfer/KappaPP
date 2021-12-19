// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
namespace Aero.Utils

open System


module ConsoleUtils =
    let cLock = "__console_lock__"

    let errorColor = ConsoleColor.Red
    let infoColor = ConsoleColor.Cyan
    let debugColor = ConsoleColor.Yellow
    let successColor = ConsoleColor.Green

    let readLine = Console.ReadLine

    let internalConsole (msg:string) (consoleColor:ConsoleColor) =
        Console.ForegroundColor <- consoleColor
        Console.WriteLine(msg)
        Console.ResetColor()        

    let console (msg:string) (consoleColor:ConsoleColor) =
        lock cLock (fun _ -> internalConsole msg consoleColor)
            
    let error  (msg:string) = console msg errorColor
    let info   (msg:string) = console msg infoColor
    let debug  (msg:string) = console msg debugColor
    let success(msg:string) = console msg successColor
    let output (msg:string) = Console.Write(msg)
    