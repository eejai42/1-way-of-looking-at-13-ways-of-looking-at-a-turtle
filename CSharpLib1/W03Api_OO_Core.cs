/* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 03: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLib1.BaseClasses;

namespace CSharpLib1
{
    // ======================================
    // Way 03 Class
    // ======================================
    public class Api_OO_Core : W03Api_OO_CoreBase
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
