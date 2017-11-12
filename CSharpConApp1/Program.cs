using CSharpLib1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var turtle = OOTurtle.RunTests<OOTurtle>();
            turtle.drawBox();
            Console.ReadKey();
        }
    }
}
