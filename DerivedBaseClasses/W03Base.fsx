(* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

W03: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors.
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

module W03Base = 
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
    
    

