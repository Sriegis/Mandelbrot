using System;
using System.Drawing;

namespace Mandelbrot
{
    public class SpiralRainbowMaker : IRainbowMaker
    {
        private readonly int _dimX;
        private readonly int _dimY;
        private readonly int _startingX;
        private readonly int _startingY;

        public SpiralRainbowMaker(int startingX, int startingY, int dimX, int dimY)
        {
            _dimX = dimX;
            _dimY = dimY;
            _startingX = startingX;
            _startingY = startingY;
        }

        public Color GetPixelColor(int x, int y)
        {
            var dist = Math.Sqrt(Math.Pow(_startingX - x, 2) + Math.Pow(_startingY - y, 2));
            var red = (int)dist % 256;
            var redBlock = (int)(dist / (_dimX/256));
            var green = dist == 0 ? 255 : 255 * ((Math.Asin((_startingY - y) / dist) + Math.PI / 2) / Math.PI);
            var blue = redBlock % 256;
            return Color.FromArgb(red, (int)green, blue);
        }
    }
}
