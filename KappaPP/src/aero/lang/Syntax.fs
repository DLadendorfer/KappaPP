// -------------------------------------------------------------------------------
// Copyright (c) Ladendorfer Daniel.  
// All Rights Reserved.  See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------
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
        | RiPepperonis | NomNom | MorphinTime | TwitchSings | LUL | CoolCat | KKona | PowerUpL | PowerUpR | TwitchVotes | FBBlock

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
        | OpAdd | OpRemove | OpDelete | OpDivide | OpMultiply | OpSubtract | OpConcat | OpDuplicate | OpLower | OpGreater | OpEquals

        // IO commands
        | IoSysout | IoSyserr

        // control flow
        | CfIf | CfElse

    type TokenValue = Literal of int | Null of string | Region of string | Stack of string | Operator of string | IO of string | CF of string

    type TokenInfo = { Raw:string; Token:Token; CompileUnit:CompileUnit; Value:TokenValue }

    let tokenInfo (token:TokenInfo) = 
        debug $"\t>>{token.Raw}::{token.CompileUnit}::{token.Value}"

    let syntax:TokenInfo list = [
        { Raw = ""; Token = Token.None; CompileUnit = CompileUnit.None; Value = Null "[null]" };  

        { Raw = "votenay"; Token = Token.VoteNay; CompileUnit = CompileUnit.I_0; Value = Literal 0 };
        { Raw = "voteyea"; Token = Token.VoteYea; CompileUnit = CompileUnit.I_1; Value = Literal 1 };
        { Raw = "tehepelo"; Token = Token.TehePelo; CompileUnit = CompileUnit.I_2; Value = Literal 2 };
        { Raw = "theilluminati"; Token = Token.TheIlluminati; CompileUnit = CompileUnit.I_3; Value = Literal 3 };
        { Raw = "ssssss"; Token = Token.SSSsss; CompileUnit = CompileUnit.I_4; Value = Literal 4 };
        { Raw = "twitchunity"; Token = Token.TwitchUnity; CompileUnit = CompileUnit.I_5; Value = Literal 5 };
        { Raw = "unsane"; Token = Token.UnSane; CompileUnit = CompileUnit.I_6; Value = Literal 6 };
        { Raw = "sabaping"; Token = Token.SabaPing; CompileUnit = CompileUnit.I_7; Value = Literal 7 };
        { Raw = "porosad"; Token = Token.PoroSad; CompileUnit = CompileUnit.I_8; Value = Literal 8 };
        { Raw = "ohmydog"; Token = Token.OhMyDog; CompileUnit = CompileUnit.I_9; Value = Literal 9 }; 
          
        { Raw = "giveplz"; Token = Token.GivePlz; CompileUnit = CompileUnit.BlockOrigin; Value = Region "[block_origin]" };
        { Raw = "takenrg"; Token = Token.TakeNRG; CompileUnit = CompileUnit.BlockEnd; Value = Region "[block_end]" };
          
        { Raw = "tbangel"; Token = Token.TbAngel; CompileUnit = CompileUnit.StackOrigin; Value = Stack "[stack_origin]" };
        { Raw = "pogchamp"; Token = Token.PogChamp; CompileUnit = CompileUnit.StackInit; Value = Stack "[stack_init]" };
        { Raw = "thankegg"; Token = Token.ThankEgg; CompileUnit = CompileUnit.StackDestroy; Value = Stack "[stack_destroy]" };
        { Raw = "copythis"; Token = Token.CopyThis; CompileUnit = CompileUnit.StackDuplicate; Value = Stack "[stack_duplicate]" }
          
        { Raw = "ripepperonis"; Token = Token.RiPepperonis; CompileUnit = CompileUnit.OpAdd; Value = Operator "[op_add]" };
        { Raw = "kkona"; Token = Token.KKona; CompileUnit = CompileUnit.OpSubtract; Value = Operator "[op_divide]" };
        { Raw = "nomnom"; Token = Token.NomNom; CompileUnit = CompileUnit.OpDelete; Value = Operator "[op_delete]" };
        { Raw = "morphintime"; Token = Token.MorphinTime; CompileUnit = CompileUnit.OpDivide; Value = Operator "[op_divide]" };
        { Raw = "twitchsings"; Token = Token.TwitchSings; CompileUnit = CompileUnit.OpMultiply; Value = Operator "[op_multiply]" };
        { Raw = "lul"; Token = Token.LUL; CompileUnit = CompileUnit.OpConcat; Value = Operator "[op_concat]" };
        { Raw = "coolcat"; Token = Token.CoolCat; CompileUnit = CompileUnit.OpDuplicate; Value = Operator "[op_duplicate]"}
        { Raw = "powerupL"; Token = Token.PowerUpL; CompileUnit = CompileUnit.OpLower; Value = Operator "[op_lower]"}
        { Raw = "powerupR"; Token = Token.PowerUpR; CompileUnit = CompileUnit.OpGreater; Value = Operator "[op_greater]"}
        { Raw = "twitchvotes"; Token = Token.TwitchVotes; CompileUnit = CompileUnit.OpEquals; Value = Operator "[op_equals]"}
        { Raw = "fbblock"; Token = Token.FBBlock; CompileUnit = CompileUnit.OpRemove; Value = Operator "[op_remove]"}
        
        { Raw = "kappa"; Token = Token.Kappa; CompileUnit = CompileUnit.IoSysout; Value = IO "[io_sysout]" }; 
        { Raw = "swiftrage"; Token = Token.SwiftRage; CompileUnit = CompileUnit.IoSyserr; Value = IO "[io_syserr]" }; 
          
        { Raw = "elegiggle"; Token = Token.EleGiggle; CompileUnit = CompileUnit.CfIf; Value = CF "[cf_if]" };
        { Raw = "jebaited"; Token = Token.Jebaited; CompileUnit = CompileUnit.CfElse; Value = CF "[cf_else]" };    
    ]
