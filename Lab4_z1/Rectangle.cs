using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4z1
{
    internal class Rectangle: Shape
    {
        public override void Draw()
        {
            Console.WriteLine($"Rysunke prostokąta o szerokości {Width} i wysokości {Height}");
        }
    }
}
