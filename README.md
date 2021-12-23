# Kappa++
## Introduction
Kappa++ is an esoteric programming language consisting of only global TwitchTV emotes. It is a stack based programming language, meaning that values can be pushed onto stacks and popped once needed. The language uses reverse polish notation (RPN) for operators.

## Hello World!

There are many ways to manipulate stacks in order to create a "Hello World!" output. This is just an example:

```
TBAngel

VoteYea PogChamp
    VoteYea CoolCat CoolCat LUL LUL
    CoolCat TheIlluminati KKona
    CoolCat
    CoolCat SabaPing KKona
    SabaPing TehePelo LUL
    KappaPride

TehePelo PogChamp
    VoteYea VoteNay LUL VoteNay LUL
    CoolCat PoroSad riPepperonis
    CoolCat UnSane riPepperonis
    CoolCat TheIlluminati KKona
    PoroSad SabaPing LUL

VoteYea PogChamp
    KappaPride
ThankEgg

SSSsss CoolCat LUL Kappa
TheIlluminati TehePelo LUL Kappa

TehePelo PogChamp
    KappaPride
ThankEgg

TheIlluminati CoolCat LUL Kappa
```

Here is a minified version of this code:
```
TBAngel VoteYea PogChamp VoteYea CoolCat CoolCat LUL LUL CoolCat TheIlluminati KKona CoolCat CoolCat SabaPing KKona SabaPing TehePelo LUL KappaPride TehePelo PogChamp VoteYea VoteNay LUL VoteNay LUL CoolCat PoroSad riPepperonis CoolCat UnSane riPepperonis CoolCat TheIlluminati KKona PoroSad SabaPing LUL VoteYea PogChamp KappaPride ThankEgg SSSsss CoolCat LUL Kappa TheIlluminati TehePelo LUL Kappa TehePelo PogChamp KappaPride ThankEgg TheIlluminati CoolCat LUL Kappa
```

## Tools
### Help
To get information about the tools of Kappa++ execute KappaPP.exe with `-help`.

```
> KappaPP.exe -help
```

### Runner
To run Kappa++ source code execute KappaPP.exe with `-run` and the path to the file containing the source code.
```
> KappaPP.exe -run "C:\Users\Admin\scripts\HelloWorld.pog"

Executing C:\Users\Admin\scripts\HelloWorld.pog:
KappaPP :: lang = K++ (V::1.0.0)
Hello, World!
```

The file extension is irrelevant. Save the file with any or no file extension.

### CLI Tool
For an interactive command line experience execute Kappa.PP.exe with `-cli`:
```
> KappaPP.exe -cli
```
<img alt ="╔══════════ K++ CLI Runtime ══════════════════════════════
╠ KappaPP :: lang = K++ (V::1.0.0)
╠ Enter K++ source lines to invoke them. Enter nothing to exit.
╠ TBAngel
╠ SabaPing TehePelo LUL Kappa VoteYea VoteNay LUL TwitchUnity LUL Kappa TheIlluminati CoolCat LUL Kappa   
╠ H
╠ i
╠ !
╠ ThankEgg
╠ 
╚══════════ K++ Finish ═══════════════════════════════════" src=https://i.imgur.com/WsGqx00.png>

# Language Reference
## Null

Any series of characters that does not match a Literal, Operator, Stack Operator, Conditional Operator or Region-Identifiers is consider a null value. This way a comment can just be written in line.

```
TBAngel <<all of this is ignored>>
comment before code: VoteYea PogChamp
[delete stack] ThankEgg
```

This piece of code is equivivalent to:
```
TBAngel
VoteYea PogChamp
ThankEgg
```
## Literals

Literals can always be pushed onto the current stack. If the value is printed the ASCII value will be printed! 

| Emote         | Literal value |
| ------------- | ------------- |
| VoteNay       | 0             |
| VoteYea       | 1             |
| TehePelo      | 2             |
| TheIlluminati | 3             |
| SSSsss        | 4             |
| TwitchUnity   | 5             |
| UnSane        | 6             |
| SabaPing      | 7             |
| PoroSad       | 8             |
| OhMyDog       | 9             |

## Keywords
| Emote | Description |
