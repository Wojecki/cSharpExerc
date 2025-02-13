using Lab4z1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Rysowanie kształtu");
    }
}
class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle {Width = 8, Height = 5},
            new Triangle {Width = 2, Height = 6},
            new Circle {Width = 6}
        };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
