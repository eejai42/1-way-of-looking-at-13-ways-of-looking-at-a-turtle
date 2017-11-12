/* ======================================
04-Api_FP_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 04: API (OO/FP hybrid approach) -- OO API calling stateless functions

In this design, an API layer communicates with pure turtle functions
and the client talks to the API layer.

The API layer manages the state (rather than the client) by storing a mutable turtle state.

*This approach has been named \
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
    // Way 04 Class
    // ======================================
    public class Api_FP_Core : W04Api_FP_CoreBase
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
