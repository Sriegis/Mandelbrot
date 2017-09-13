using System;
using System.Drawing;

namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dim = 4096;

            //var picture = new Bitmap(dim, dim);
            //var color = Color.Empty;
            //var xBox = 0;
            //var yBox = 0;

            //Console.WriteLine("Processing...");
            //for (var x = 0; x < picture.Width; x++)
            //{
            //    for (var y = 0; y < picture.Height; y++)
            //    {
            //        xBox = x / 256;
            //        yBox = y / 256;
            //        color = Color.FromArgb(x % 256, y % 256, 16*xBox + yBox);
            //        picture.SetPixel(x, y, color);
            //    }
            //}

            //Console.WriteLine("Done!");
            //picture.Save("Mandelbrot.bmp");
            //Console.ReadKey();

            Console.WriteLine("Processing...");

            var mandebrot = new Mandelbrot(4096);

            Console.WriteLine("Done!");

            mandebrot.Picture.Save("Mandelbrot.bmp");
            //Console.ReadKey();
        }
    }
}
