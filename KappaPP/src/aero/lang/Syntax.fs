namespace Aero.Lang

module Syntax =
    open Aero.Utils.ConsoleUtils

    type [<RequireQualifiedAccess>]  Token =
    // type token list [name = Twitch Emote name]
        // None
        | None

        // literals [numbers]
        | VoteNay | VoteYea | TehePelo | TheIlluminati | SSSsss | TwitchUnity | UnSane | SabaPing | PoroSad | OhMyDog           

        // region definers 
        | TbAngel | GivePlz | TakeNRG
        
        // stack commands
        | PogChamp | ThankEgg | CopyThis

        // operators
        | RiPepperonis | NomNom | MorphinTime | TwitchSings | LUL | CoolCat | KKona

        // IO commands
        | Kappa | SwiftRage

        // control flow
        | EleGiggle | Jebaited

    type [<RequireQualifiedAccess>]  CompileUnit =
    // type token list [name = Twitch Emote name]
        // None
        | None
        
        // literals [numbers]
        | I_0 | I_1 | I_2 | I_3 | I_4 | I_5 | I_6 | I_7 | I_8 | I_9

        // region definers 
        | StackOrigin | BlockOrigin | BlockEnd


        // stack commands
        | StackInit | StackDestroy | StackDuplicate

        // operators
        | OpAdd | OpDelete | OpDivide | OpMultiply | OpSubtract | OpConcat | OpDuplicate

        // IO commands
        | IoSysout | IoSyserr

        // control flow
        | CfIf | CfElse

    type TokenValue = Literal of int | Null of string | Region of string | Stack of string | Operator of string | IO of string | CF of string

    type TokenInfo = { Id:byte; Raw:string; Token:Token; CompileUnit:CompileUnit; Value:TokenValue }

    let tokenInfo (token:TokenInfo) = 
        info token.Raw
        debug $"\t>>0x{token.Id:X2}::{token.CompileUnit}::{token.Value}"

    let syntax:TokenInfo list = [
        { Id = byte 0xFF; Raw = ""; Token = Token.None; CompileUnit = CompileUnit.None; Value = Null "[null]" };  

        { Id = byte 0x0; Raw = "votenay"; Token = Token.VoteNay; CompileUnit = CompileUnit.I_0; Value = Literal 0 };
        { Id = byte 0x1; Raw = "voteyea"; Token = Token.VoteYea; CompileUnit = CompileUnit.I_1; Value = Literal 1 };
        { Id = byte 0x2; Raw = "tehepelo"; Token = Token.TehePelo; CompileUnit = CompileUnit.I_2; Value = Literal 2 };
        { Id = byte 0x3; Raw = "theilluminati"; Token = Token.TheIlluminati; CompileUnit = CompileUnit.I_3; Value = Literal 3 };
        { Id = byte 0x4; Raw = "ssssss"; Token = Token.SSSsss; CompileUnit = CompileUnit.I_4; Value = Literal 4 };
        { Id = byte 0x5; Raw = "twitchunity"; Token = Token.TwitchUnity; CompileUnit = CompileUnit.I_5; Value = Literal 5 };
        { Id = byte 0x6; Raw = "unsane"; Token = Token.UnSane; CompileUnit = CompileUnit.I_6; Value = Literal 6 };
        { Id = byte 0x7; Raw = "sabaping"; Token = Token.SabaPing; CompileUnit = CompileUnit.I_7; Value = Literal 7 };
        { Id = byte 0x8; Raw = "porosad"; Token = Token.PoroSad; CompileUnit = CompileUnit.I_8; Value = Literal 8 };
        { Id = byte 0x9; Raw = "ohmydog"; Token = Token.OhMyDog; CompileUnit = CompileUnit.I_9; Value = Literal 9 }; 
                      
        { Id = byte 0x10; Raw = "giveplz"; Token = Token.GivePlz; CompileUnit = CompileUnit.BlockOrigin; Value = Region "[block_origin]" };
        { Id = byte 0x11; Raw = "takenrg"; Token = Token.TakeNRG; CompileUnit = CompileUnit.BlockEnd; Value = Region "[block_end]" };
                         
        { Id = byte 0x20; Raw = "tbangel"; Token = Token.TbAngel; CompileUnit = CompileUnit.StackOrigin; Value = Stack "[stack_origin]" };
        { Id = byte 0x21; Raw = "pogchamp"; Token = Token.PogChamp; CompileUnit = CompileUnit.StackInit; Value = Stack "[stack_init]" };
        { Id = byte 0x22; Raw = "thankegg"; Token = Token.ThankEgg; CompileUnit = CompileUnit.StackDestroy; Value = Stack "[stack_destroy]" };
        { Id = byte 0x23; Raw = "copythis"; Token = Token.CopyThis; CompileUnit = CompileUnit.StackDuplicate; Value = Stack "[stack_duplicate]" }
                         
        { Id = byte 0x30; Raw = "ripepperonis"; Token = Token.RiPepperonis; CompileUnit = CompileUnit.OpAdd; Value = Operator "[op_add]" };
        { Id = byte 0x32; Raw = "kkona"; Token = Token.KKona; CompileUnit = CompileUnit.OpSubtract; Value = Operator "[op_divide]" };
        { Id = byte 0x31; Raw = "nomnom"; Token = Token.NomNom; CompileUnit = CompileUnit.OpDelete; Value = Operator "[op_delete]" };
        { Id = byte 0x32; Raw = "morphintime"; Token = Token.MorphinTime; CompileUnit = CompileUnit.OpDivide; Value = Operator "[op_divide]" };
        { Id = byte 0x33; Raw = "twitchsings"; Token = Token.TwitchSings; CompileUnit = CompileUnit.OpMultiply; Value = Operator "[op_multiply]" };
        { Id = byte 0x34; Raw = "lul"; Token = Token.LUL; CompileUnit = CompileUnit.OpConcat; Value = Operator "[op_concat]" };
        { Id = byte 0x35; Raw = "coolcat"; Token = Token.CoolCat; CompileUnit = CompileUnit.OpDuplicate; Value = Operator "[op_duplicate]"}
                         
        { Id = byte 0x40; Raw = "kappa"; Token = Token.Kappa; CompileUnit = CompileUnit.IoSysout; Value = IO "[io_sysout]" }; 
        { Id = byte 0x41; Raw = "swiftrage"; Token = Token.SwiftRage; CompileUnit = CompileUnit.IoSyserr; Value = IO "[io_syserr]" }; 
                         
        { Id = byte 0x50; Raw = "elegiggle"; Token = Token.EleGiggle; CompileUnit = CompileUnit.CfIf; Value = CF "[cf_if]" };
        { Id = byte 0x51; Raw = "jebaited"; Token = Token.Jebaited; CompileUnit = CompileUnit.CfElse; Value = CF "[cf_else]" };    
    ]
