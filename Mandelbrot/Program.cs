using System;

namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing...");

            // resolution for mandebrot must be of ratio 1024/600
            var dimX = 11264;
            var dimY = 6600;

            var outerMaker = new SpiralRainbowMaker((int)(dimX * 0.8d), dimY / 2, dimX, dimY);
            var innerMaker = new StatefulRainbowMaker();

            var mandebrot = new Mandelbrot(dimX, dimY, outerMaker, innerMaker, System.Drawing.Color.Aqua);

            Console.WriteLine("Done!");

            mandebrot.Picture.Save("Mandelbrot.bmp");
            System.Diagnostics.Process.Start("Mandelbrot.bmp");
        }
    }
}
