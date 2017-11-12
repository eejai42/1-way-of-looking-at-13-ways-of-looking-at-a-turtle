/* ======================================
02-FPTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 02: Simple FP - a module of functions with immutable state

In this design, the turtle state is immutable. A module contains functions that return a new turtle state,
and the client uses these turtle functions directly.

The client must keep track of the current state and pass it into the next function call.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonExtensions;

namespace CSharpLib1.BaseClasses
{

    public static class TurtleExtensions {
        public static Turtle CreateTurtle(log log) {
            return new Turtle(log);
        }

        public static Turtle DoMove(this Turtle turtle, float distance) {
            turtle.Move(distance);
            return turtle;
        }

        public static Turtle DoTurn(this Turtle turtle, float angle)
        {
            turtle.Turn(angle);
            return turtle;
        }

    }

    // ======================================
    // Way 02 Helper Classes
    // ======================================
    public abstract class W02FPTurtleBase : TurtleBase
    {
        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");
            TurtleExtensions.CreateTurtle(log)
                .DoMove(100)
                .DoTurn(120)
                .DoMove(100)
                .DoTurn(120);
        }
        
        public override void drawThreeLines()
        {
            this.log("PRINTING ThreeLines!");
            var turtle = new Turtle(log);

            
            // Draw black line
            turtle.PenDown();
            turtle.SetColor(PenColor.Black);
            turtle.Move(100);
            // Move without Drawing
            turtle.PenUp();
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            // Draw red line
            turtle.PenDown();
            turtle.SetColor(PenColor.Red);
            turtle.Move(100);
            // Move without Drawing
            turtle.PenUp();
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            // Back home at (0,0) with angle 0, Draw diagonal blue line
            turtle.PenDown();
            turtle.SetColor(PenColor.Blue);
            turtle.Turn(45);
            turtle.Move(100);
        }
        
        public void drawBox()
        {
            this.log("PRINTING Box!");
            var turtle = new Turtle(log);

            
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
        }
    }
}


    

