using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class Mandelbrot
    {
        public Bitmap Picture { get; }

        public Mandelbrot(int dimensions)
        {
            Picture = GeneratePicture(dimensions);
        }

        private Bitmap GeneratePicture(int dimensions)
        {
            var picture = new Bitmap(dimensions, dimensions);
            var color = Color.Empty;

            Console.WriteLine("Generating Mandelbrot set...");
            for (var x = 0; x < picture.Width; x++)
            {
                for (var y = 0; y < picture.Height; y++)
                {
                    var colVal = GetMandelbrotIterations(x, y, dimensions) % 256;
                    color = Color.FromArgb(colVal, colVal, colVal);
                    picture.SetPixel(x, y, color);
                }
            }

            return picture;
        }

        private int GetMandelbrotIterations(int coordX, int coordY, int dim)
        {
            var x = 0d;
            var y = 0d;
            var xtemp = 0d;
            var iterations = 0;

            while (x * x + y * y < 4 && iterations < 1000)
            {
                xtemp = x * x - y * y + ScaleCoordinate(coordX, dim, -2.5d, 3.5d);
                y = 2 * x * y + ScaleCoordinate(coordY, dim, -1d, 2d);
                x = xtemp;
                iterations += 1;
            }

            return iterations;
        }

        private double ScaleCoordinate(int coord, int dim, double scaleStart, double scaleLength)
        {
            var scaleFactor = (double)coord / dim;
            var scaleAmount = scaleLength * scaleFactor;
            return scaleStart + scaleAmount;
        }
    }
}
