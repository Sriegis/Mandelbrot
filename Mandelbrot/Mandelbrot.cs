using System;
using System.Drawing;

namespace Mandelbrot
{
    public class Mandelbrot
    {
        public Bitmap Picture { get; }

        private readonly IRainbowMaker _rainbowMaker;
        private readonly Color _baseColor;
        private const int MaxIterations = 255;
        private readonly IRainbowMaker _innerRainbowMaker;

        public Mandelbrot(int dimX, int dimY, IRainbowMaker rainbowMaker, IRainbowMaker innerRainbowMaker, Color baseColor)
        {
            _rainbowMaker = rainbowMaker;
            _baseColor = baseColor;
            _innerRainbowMaker = innerRainbowMaker;
            Picture = GeneratePicture(dimX, dimY);
        }

        private Bitmap GeneratePicture(int dimX, int dimY)
        {
            var picture = new Bitmap(dimX, dimY);

            Console.WriteLine("Generating Mandelbrot set...");

            for (var x = 0; x < picture.Width; x++)
            {
                for (var y = 0; y < picture.Height; y++)
                {
                    var iterations = GetMandelbrotIterations(x, y, dimX, dimY);
                    var color = GetColor(iterations, x, y);
                    picture.SetPixel(x, y, color);
                }
            }

            return picture;
        }

        private Color GetColor(int iterations, int x, int y)
        {
            var color = iterations > MaxIterations - 5 ? _innerRainbowMaker.GetPixelColor(x, y) : MeshColors(iterations, _baseColor, Color.PaleVioletRed);
            return color;
        }

        private Color MeshColors(int iterations, Color basicColor, Color rainbow)
        {
            var iterationFactor = (double)iterations / MaxIterations;
            var red = iterationFactor * rainbow.R + (1 - iterationFactor) * basicColor.R;
            var green = iterationFactor * rainbow.G + (1 - iterationFactor) * basicColor.G;
            var blue = iterationFactor * rainbow.B + (1 - iterationFactor) * basicColor.B;

            return Color.FromArgb((int)red, (int)green, (int)blue);
        }


        private int GetMandelbrotIterations(int coordX, int coordY, int dimX, int dimY)
        {
            var x = 0d;
            var y = 0d;
            var iterations = 0;

            while (x * x + y * y < 4 && iterations < MaxIterations)
            {
                var xtemp = x * x - y * y + ScaleCoordinate(coordX, dimX, -2.8d, 3.5d);
                y = 2 * x * y + ScaleCoordinate(coordY, dimY, -1d, 2d);
                x = xtemp;
                iterations += 1;
            }

            return Math.Min(iterations * 5, MaxIterations);
        }

        private double ScaleCoordinate(int coord, int dim, double scaleStart, double scaleLength)
        {
            var scaleFactor = (double)coord / dim;
            var scaleAmount = scaleLength * scaleFactor;
            return scaleStart + scaleAmount;
        }
    }
}
