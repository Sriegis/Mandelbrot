using System;
using System.Drawing;

namespace Mandelbrot
{
    public class Mandelbrot
    {
        public Bitmap Picture { get; }

        private readonly IRainbowMaker _rainbowMaker;
        private const int MaxIterations = 255;
        private const double InterpolationFactor = 0.5d;

        public Mandelbrot(int dimX, int dimY, IRainbowMaker rainbowMaker)
        {
            _rainbowMaker = rainbowMaker;
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
            // todo: instead of aqua maybe a gradient?
            var aquaR = 0;
            var aquaG = 255;
            var aquaB = 255;
            var color = MeshColors(iterations, Color.Aqua, _rainbowMaker.GetPixelColor(x, y));
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


        private Color ApplyRainbow(Color color, int x, int y)
        {
            var rainbow = _rainbowMaker.GetPixelColor(x, y);
            var red = InterpolateColor((int)(rainbow.R * color.R / 255d), rainbow.R);
            var green = InterpolateColor((int)(rainbow.G * color.G / 255d), rainbow.G);
            var blue = InterpolateColor((int)(rainbow.B * color.B / 255d), rainbow.B);
            return Color.FromArgb(red, green, blue);
        }

        private int InterpolateColor(int color, int adition)
        {
            return color == 255 ? color : Math.Min(255, color + (int)(InterpolationFactor * adition));
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
