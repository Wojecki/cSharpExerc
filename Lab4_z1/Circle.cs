using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4z1
{
    internal class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine($"Rysunek koła o średnicy {Width}");
        }
    }
}
