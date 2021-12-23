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