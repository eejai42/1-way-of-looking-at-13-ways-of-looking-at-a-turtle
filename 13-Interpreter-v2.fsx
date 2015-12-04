﻿(* ======================================
13-Interpreter-v2.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #13: The interpreter pattern

In this design, the client builds a data structure (`TurtleProgram`) that represents the instructions.

This Turtle Program can then interpreted later in various ways

====================================== *)


open System

#load "Common.fsx"
#load "FPTurtleLib2.fsx"

open System
open Common
open FPTurtleLib2


// ============================================================================
// Turtle Program V2 
//  * Stop case is moved to a separate type - main type has only relevant commands
//  * Generic, so bind will work
// ============================================================================

module TurtleProgram_v2 = 
    open Turtle

    /// Create a type to represent each instruction
    type TurtleInstruction<'next> = 
        | Move of Distance * (MoveResponse -> 'next)
        | Turn of Angle * (unit -> 'next)
        | PenUp of (unit -> 'next)
        | PenDown of (unit -> 'next)
        | SetColor of PenColor * (SetColorResponse -> 'next)

    /// Create a type to represent the Turtle Program
    type TurtleProgram<'a> = 
        | Stop of 'a
        | KeepGoing of TurtleInstruction<TurtleProgram<'a>>


    /// map the instructions
    let mapInstr f inst  = 
        match inst with
        | Move(dist,next) -> Move(dist,fun response -> f(next response)) 
        | Turn(angle,next) -> Turn(angle,next >> f)  // "next >> f" is shorter version 
        | PenUp(next) -> PenUp(next >> f)
        | PenDown(next) -> PenDown(next >> f)
        | SetColor(color,next) -> SetColor(color,next >> f)

    let returnT x = 
        Stop x 

    let rec bindT f program = 
        match program with
        | KeepGoing instruction -> 
            KeepGoing (mapInstr (bindT f) instruction)
        | Stop x -> 
            f x

    // define a computation expression builder
    type TurtleProgramBuilder() =
        member this.Return(x) = returnT x
        member this.Bind(x,f) = bindT f x
        member this.Zero(x) = returnT ()

    // create an instance of the computation expression builder
    let turtleProgram = TurtleProgramBuilder()

// ------------------------
// Example of Turtle Program V2 object
// ------------------------

module TurtleProgram_v2_Example = 
    open TurtleProgram_v2

    // example
    let drawTriangle = 
        KeepGoing (Move (100.0, fun response  -> 
        KeepGoing (Turn (120.0<Degrees>, fun () -> 
        KeepGoing (Move (100.0, fun response  -> 
        KeepGoing (Turn (120.0<Degrees>, fun () -> 
        KeepGoing (Move (100.0, fun response  -> 
        KeepGoing (Turn (120.0<Degrees>, fun () -> 
        Stop () ))))))))))))
    // val drawTriangle : TurtleProgram<unit>  

    // helper functions
    let stop x = Stop x
    let move dist  = KeepGoing (Move (dist, stop))
    let turn angle  = KeepGoing (Turn (angle, stop))
    let penUp  = KeepGoing (PenUp stop)
    let penDown  = KeepGoing (PenDown stop)
    let setColor color = KeepGoing (SetColor (color,stop))

    let handleMoveReponse log moveResponse = turtleProgram {
        match moveResponse with
        | Turtle.MoveOk -> 
            ()
        | Turtle.HitABarrier ->
            // turn 90 before trying again
            log "Oops -- hit a barrier -- turning"
            let! x = turn 90.0<Degrees>
            ()
        }

    // example
    let drawTwoLines log = turtleProgram {
        let! response = move 60.0
        do! handleMoveReponse log response 
        let! response = move 60.0
        do! handleMoveReponse log response 
        }
    // val drawTwoLines: TurtleProgram<unit>


// ------------------------
// Interpreters for Turtle Program v2
// ------------------------

module TurtleProgram_v2_Interpreter = 
    open TurtleProgram_v2

    /// Interpret as a turtle
    let rec interpretAsTurtle log state program =
        let recurse = interpretAsTurtle log 
        
        match program with
        | Stop a -> 
            state
        | KeepGoing (Move (dist,next)) ->
            let result,newState = Turtle.move log dist state 
            let nextProgram = next result 
            recurse newState nextProgram 
        | KeepGoing (Turn (angle,next)) ->
            let newState = Turtle.turn log angle state 
            let nextProgram = next()
            recurse newState nextProgram 
        | KeepGoing (PenUp next) ->
            let newState = Turtle.penUp log state 
            let nextProgram = next()
            recurse newState nextProgram 
        | KeepGoing (PenDown next) -> 
            let newState = Turtle.penDown log state 
            let nextProgram = next()
            recurse newState nextProgram 
        | KeepGoing (SetColor (color,next)) ->
            let result,newState = Turtle.setColor log color state 
            let nextProgram = next result
            recurse newState nextProgram 

    /// Interpret as a distance
    let rec interpretAsDistance distanceSoFar program =
        let recurse = interpretAsDistance 
        let log = printfn "%s"
        
        match program with
        | Stop a -> 
            distanceSoFar
        | KeepGoing (Move (dist,next)) ->
            let newDistanceSoFar = distanceSoFar + dist
            let result = Turtle.MoveOk
            let nextProgram = next result 
            recurse newDistanceSoFar nextProgram 
        | KeepGoing (Turn (angle,next)) ->
            // no change in distanceSoFar
            let nextProgram = next()
            recurse distanceSoFar nextProgram 
        | KeepGoing (PenUp next) ->
            // no change in distanceSoFar
            let nextProgram = next()
            recurse distanceSoFar nextProgram 
        | KeepGoing (PenDown next) -> 
            // no change in distanceSoFar
            let nextProgram = next()
            recurse distanceSoFar nextProgram 
        | KeepGoing (SetColor (color,next)) ->
            // no change in distanceSoFar
            let result = Turtle.ColorOk
            let nextProgram = next result
            recurse distanceSoFar nextProgram 

// ------------------------
// TurtleProgram_v2_Interpreter Tests
// ------------------------

// Interpret `drawTriangle` as turtle
do 
    let log = printfn "%s"
    let interpret = TurtleProgram_v2_Interpreter.interpretAsTurtle 
    let program = TurtleProgram_v2_Example.drawTriangle
    let initialState = Turtle.initialTurtleState
    interpret log initialState program |> ignore

// Interpret `drawTriangle` as distance
do 
    let interpret = TurtleProgram_v2_Interpreter.interpretAsDistance
    let program = TurtleProgram_v2_Example.drawTriangle
    let initialState = 0.0
    interpret initialState program |> printfn "Total distance moved is %0.1f"

  
// Interpret `drawTwoLines` as turtle
do 
    let log = printfn "%s"
    let interpret = TurtleProgram_v2_Interpreter.interpretAsTurtle 
    let program = TurtleProgram_v2_Example.drawTwoLines log 
    let initialState = Turtle.initialTurtleState
    interpret log initialState program |> ignore

// Interpret `drawTwoLines` as distance
do 
    let log = printfn "%s"
    let interpret = TurtleProgram_v2_Interpreter.interpretAsDistance 
    let program = TurtleProgram_v2_Example.drawTwoLines log 
    let initialState = 0.0
    interpret initialState program |> printfn "Total distance moved is %0.1f"
