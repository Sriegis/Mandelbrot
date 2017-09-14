using System;

namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing...");

            var dimX = 512;
            var dimY = 300;

            // resolution for mandebrot must be of ratio 1024/600

            //var rainbowMaker = new SquareRainbowMaker();
            //var mandebrot = new Mandelbrot(8192, 4800, rainbowMaker);

            var rainbowMaker = new ContinuousRainbowMaker(dimX, dimY);

            var mandebrot = new Mandelbrot(dimX, dimY, rainbowMaker);

            Console.WriteLine("Done!");

            mandebrot.Picture.Save("Mandelbrot.bmp");
            //System.Diagnostics.Process.Start("Mandelbrot.bmp");
            //Console.ReadKey();
        }
    }
}
