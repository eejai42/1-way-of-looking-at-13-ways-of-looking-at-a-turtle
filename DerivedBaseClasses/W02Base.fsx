(* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

W02: Simple FP - a module of functions with immutable state

In this design, the turtle state is immutable. A module contains functions that return a new turtle state,
and the client uses these turtle functions directly.

The client must keep track of the current state and pass it into the next function call.
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

module W02Base = 
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
    
    

