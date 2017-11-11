(* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

W09: Batch oriented -- Using a list of commands

In this design, the client creates a list of `Command`s that will be intepreted later.
These commands are then run in sequence using the Turtle library functions.

This approach means that there is no state that needs to be persisted between calls by the client.
====================================== *)

#load "../Common.fsx"

open System
open Common

// ======================================
// OO Turtle
// ======================================

// see code in this file
#load "../OOTurtleLib.fsx"

// ======================================
// OO Turtle Client
// ======================================

module W09Base = 
    open OOTurtleLib

    /// Function to log a message
    let log message =
        printfn "%s" message 

    
    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"
        let turtle = Turtle(log)
        
        turtle.Move 100.0
        turtle.Turn 120.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 120.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 120.0<Degrees>
    
    
    let drawThreeLines() = 
        printfn "PRINTING ThreeLines!"
        let turtle = Turtle(log)
        
        // Draw black line
        turtle.PenDown ()
        turtle.SetColor Black
        turtle.Move 100.0
        // Move without Drawing
        turtle.PenUp ()
        turtle.Turn 90.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
        // Draw red line
        turtle.PenDown ()
        turtle.SetColor Red
        turtle.Move 100.0
        // Move without Drawing
        turtle.PenUp ()
        turtle.Turn 90.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
        // Back home at (0,0) with angle 0, Draw diagonal blue line
        turtle.PenDown ()
        turtle.SetColor Blue
        turtle.Turn 45.0<Degrees>
        turtle.Move 100.0
    
    
    let drawBox() = 
        printfn "PRINTING Box!"
        let turtle = Turtle(log)
        
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
        turtle.Move 100.0
        turtle.Turn 90.0<Degrees>
    
    

