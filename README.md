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

Here is the Twitch Chat version of it:<br>
<img src="https://i.imgur.com/eGgYNPn.png">

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


## IO Operators


| Emote      | Description                                                                                                                            |
| ---------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| Kappa      | Prints the ASCII value of the current stacks top value. The value will be popped off the stack. (SYS_OUT)                              |
| KappaPride | Prints the ASCII values of all values of the current stack. The values will be popped off the stack, leaving an empty stack. (SYS_OUT) |
| SwiftRage  | Same as Kappa, but SwiftRage should be used for errors. (ERR_OUT)                                                                      |
| SingsMic   | The caller of the program is forced to enter a line. The values will be pushed onto the current stack. (SYS_IN)                        |

## Literal Operators
These operators manipulate the current stacks top values. The values may be popped, peeked or replaced by the result of the operator.
| Emote        | Description                                                                                                                                                                                                                         |
| ------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| riPepperonis | Pops the top two values of the current stack, sums them and pushes the result onto the current stack.                                                                                                                               |
| KKona        | Pops the top two values of the current stack, subtracts the top value from the second top value and pushes the result onto the current stack.                                                                                       |
| FBBlock      | Pops the top value. (This can be useful to pop a condition if it is not needed anymore)                                                                                                                                             |
| MorphinTime  | Pops the top two values of the current stack, divides the second top value by the top most value and pushes the result onto the current stack.                                                                                      |
| TwitchSings  | Pops the top two values of the current stack, multiplies top value by the second top value and pushes the result onto the current stack.                                                                                            |
| LUL          | Pops the top two values of the current stack and concatenates them. e.g.: If the stack was 1>2>3, the stack will be 1>23 because the 2 and 3 got concatenated.                                                                      |
| CoolCat      | Peeks the top value of the current stack and pushes it again onto the stack (duplicating the top value).                                                                                                                            |
| PowerUpL     | Peeks the top two values of the current stack and checks if the second top value is lower than the top value. If it is lower a 1 (VoteYea) will be pushed onto the stack otherwise a 0 (VoteNay) will be pushed onto the stack.     |
| PowerUpR     | Peeks the top two values of the current stack and checks if the second top value is greater than the top value. If it is greater a 1 (VoteYea) will be pushed onto the stack otherwise a 0 (VoteNay) will be pushed onto the stack. |
| TwitchVotes  | Peeks the top two values of the current stack and checks if the second top value is equal to the top value. If it is equal a 1 (VoteYea) will be pushed onto the stack otherwise a 0 (VoteNay) will be pushed onto the stack.       |

## Region Operators
A region of code has an origin and an end. These regions can be skipped with conditional operators.
| Emote   | Description              |
| ------- | ------------------------ |
| GivePLZ | Opens a region of code.  |
| TakeNRG | Closes a region of code. |

## Conditional Operators
In Kappa++ regions of code can be skipped if a conditional operator evaluates to true. If the evaluation is successful the next region is skipped. It does not have to be directly after the condition but it is recommended.

| Emote     | Description                                                                                 |
| --------- | ------------------------------------------------------------------------------------------- |
| EleGiggle | Peeks the top value of the stack. If it is not 0 (VoteNay) the next region will be skipped. |
| Jebaited  | Peeks the top value of the stack. If it is 0 (VoteNay) the next region will be skipped.     |



## Stack Operators
These operators manipulate, create or set the current stack. There can be an unlimited number of stacks with unlimited number of values pushed onto the stacks. <br>
Per default the current stack is the ORIGIN stack. Working on the ORIGIN stack is considerd bad habit but it is possible. The ORIGIN stack should only be active to create other stacks.

| Emote    | Description                                                                                                                                                                                                                                                                                            |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| TBAngel  | Sets the current stack to the ORIGIN stack.                                                                                                                                                                                                                                                            |
| PogChamp | Creates a new stack and sets it as the current stack. The ID of the stack is the top value of the current stack. The top value will be popped off the stack. If PogChamp is called with an ID of an existing stack, the current stack will be set to the existing stack instead of creating a new one. |
| ThankEgg | Destroys the current stack with all it's content and sets the current stack to ORIGIN.                                                                                                                                                                                                                 |
| CopyThis | Creates a new stack and sets it as the current stack. The content of the new stack is equal to the previously active stack. The ID of the stack is the top value of the current stack. The top value will be popped off the stack.                                                                     |

# Language Safety
The language is very forgiving and errors should not be possible. For example, if an operator is peeking or popping an empty stack a 0 (VoteNay) is returned instead of exiting with an error.
 