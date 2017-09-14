using System;

namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing...");

            // resolution for mandebrot must be of ratio 1024/600
            //var dimX = 16384;
            //var dimY = 9600;
            //var dimX = 2048;
            //var dimY = 1200;
            var dimX = 4096;
            var dimY = 2400;

            //var rainbowMaker = new SquareRainbowMaker();
            //var rainbowMaker = new ContinuousRainbowMaker(dimX, dimY);
            var rainbowMaker = new SpiralRainbowMaker((int)(dimX*0.8d), dimY/2, dimX, dimY);

            var mandebrot = new Mandelbrot(dimX, dimY, rainbowMaker);

            Console.WriteLine("Done!");

            mandebrot.Picture.Save("Mandelbrot.bmp");
            System.Diagnostics.Process.Start("Mandelbrot.bmp");
            //Console.ReadKey();
        }
    }
}
