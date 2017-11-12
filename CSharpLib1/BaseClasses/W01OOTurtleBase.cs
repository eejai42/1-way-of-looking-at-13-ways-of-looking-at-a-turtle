using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    public abstract class W01OOTurtleBase : TurtleBase
    {
        public override void drawTriangle()
        {
            var turtle = new Turtle(log);
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
            turtle.Turn(120);
        }

        public override void drawThreeLines()
        {
            throw new NotImplementedException();
        }
    }
}
