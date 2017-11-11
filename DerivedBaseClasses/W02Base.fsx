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
// FP Turtle
// ======================================

// see code in this file
#load "../FPTurtleLib.fsx"
open FPTurtleLib

// ======================================
// WO2 helpers
// ======================================

module W02Base = 
    open FPTurtleLib

    /// Function to log a message
    let log message =
        printfn "%s" message 

    let move = Turtle.move log
    let turn = Turtle.turn log
    let penDown = Turtle.penDown log
    let penUp = Turtle.penUp log
    let setColor = Turtle.setColor log

    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"

        Turtle.initialTurtleState
        |> move 100.0 
        |> turn 120.0<Degrees>
        |> move 100.0 
        |> turn 120.0<Degrees>
        |> move 100.0 
        |> turn 120.0<Degrees>
        // back home at (0,0) with angle 0
    
    
    let drawThreeLines() = 
        printfn "PRINTING ThreeLines!"
       
        Turtle.initialTurtleState
        // draw black line 
        |> penDown
        |> setColor Black
        |> move 100.0 
        // move without drawing
        |> penUp
        |> turn 90.0<Degrees>
        |> move 100.0 
        |> turn 90.0<Degrees>
        // draw red line 
        |> penDown
        |> setColor Red
        |> move 100.0
        // move without drawing
        |> penUp
        |> turn 90.0<Degrees>
        |> move 100.0 
        |> turn 90.0<Degrees>
        // back home at (0,0) with angle 0
        // draw diagonal blue line 
        |> penDown
        |> setColor Blue
        |> turn 45.0<Degrees>
        |> move 100.0
    
    
    let drawBox() = 
        printfn "PRINTING Box!"
        
        Turtle.initialTurtleState
        |> move 100.0 
        |> turn 90.0<Degrees>
        |> move 100.0 
        |> turn 90.0<Degrees>
        |> move 100.0 
        |> turn 90.0<Degrees>
        |> move 100.0 
        |> turn 90.0<Degrees>
        // back home at (0,0) with angle 0
    
    

