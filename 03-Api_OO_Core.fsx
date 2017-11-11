(* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #3: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors. 

====================================== *)

#load "DerivedBaseClasses/W03Base.fsx"

#load "Common.fsx"
#load "OOTurtleLib.fsx"


open System
open Common


// ======================================
// Turtle Api Client
// ======================================

module TurtleApiClient = 
    open W03Base

    let drawTriangle() = 
        W03Base.drawTriangle();
            
    let drawThreeLines() = 
        let api = W03Base.TurtleApi()
        // draw black line 
        api.Exec "Pen Down"
        api.Exec "SetColor Black"
        api.Exec "Move 100"
        // move without drawing
        api.Exec "Pen Up"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        // draw red line 
        api.Exec "Pen Down"
        api.Exec "SetColor Red"
        api.Exec "Move 100"
        // move without drawing
        api.Exec "Pen Up"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        // back home at (0,0) with angle 0
        // draw diagonal blue line 
        api.Exec "Pen Down"
        api.Exec "SetColor Blue"
        api.Exec "Turn 45"
        api.Exec "Move 100"

    let drawPolygon n = 
        let angle = 180.0 - (360.0/float n) 
        let api = W03Base.TurtleApi()

        // define a function that draws one side
        let drawOneSide() = 
            api.Exec "Move 100.0"
            api.Exec (sprintf "Turn %f" angle)

        // repeat for all sides
        for i in [1..n] do
            drawOneSide()

    let triggerError() = 
        let api = W03Base.TurtleApi()
        api.Exec "Move bad"

// ======================================
// Turtle API tests
// ======================================

TurtleApiClient.drawTriangle() 
TurtleApiClient.drawThreeLines() 
TurtleApiClient.drawPolygon 4 

// test errors
TurtleApiClient.triggerError()
// Exception of type 'TurtleApiException' was thrown.

