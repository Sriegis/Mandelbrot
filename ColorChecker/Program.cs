using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = @"C:\Users\Linas\Documents\visual studio 2017\Projects\Mandelbrot\Mandelbrot\bin\Debug\Mandelbrot.bmp";
            Console.WriteLine($"Does {filename} contain all rgb colors?");

            var pic = new Bitmap(filename);

            var colors = new bool[256, 256, 256];

            for (var height = 0; height < pic.Height; height++)
            {
                for (var width = 0; width < pic.Width; width++)
                {
                    var pixel = pic.GetPixel(width, height);
                    colors[pixel.R, pixel.G, pixel.B] = true;
                }
            }

            for (var r = 0; r <= 255; r++)
            {
                for (var g = 0; g <= 255; g++)
                {
                    for (var b = 0; b <= 255; b++)
                    {
                        if (!colors[r, g, b])
                        {
                            Console.WriteLine($"Color {r} {g} {b} is not present in the file.");
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
