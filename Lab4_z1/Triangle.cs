using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4z1
{
    internal class Triangle :Shape
    {
        public override void Draw()
        {
            Console.WriteLine($"Rysunek trójkąta o wysokości {Height} i szerokości {Width}");
        }
    }
}
