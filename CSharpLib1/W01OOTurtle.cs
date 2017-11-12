/* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #1: Simple OO -- a class with mutable state

In this design, a simple OO class represents the turtle,
and the client talks to the turtle directly.

====================================== */
using CSharpLib1.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1
{


    // ======================================
    // OO Turtle Client
    // ======================================

    public class OOTurtleClient : W01OOTurtleBase
    {


        // define a function that draws one side
        private void drawOneSide(Turtle turtle, float angleDegrees)
        {
            turtle.Move(100);
            turtle.Turn(angleDegrees);
        }

        public override void drawPolygon(int n)
        {
            var angle = 180.0 - (360.0 / (float)n);
            var angleDegrees = angle * 1.0f;
            var turtle = new Turtle(log);


            // repeat for all sides
            for (var i = 0; i < n; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

    }
}
