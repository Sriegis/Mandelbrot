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
        private Color _lastColor;

        public SpiralRainbowMaker(int startingX, int startingY, int dimX, int dimY)
        {
            _dimX = dimX;
            _dimY = dimY;
            _startingX = startingX;
            _startingY = startingY;
            _lastColor = new Color();
        }

        public Color GetPixelColor(int x, int y)
        {
            // raudona nuo atstumo
            // melyna i kaire
            // zalia i desine
            var dist = Math.Sqrt(Math.Pow(_startingX - x, 2) + Math.Pow(_startingY - y, 2));
            var red = (int)dist % 256;
            var redBlock = (int)(dist / (_dimX/256)); // will be used for blue
            var green = dist == 0 ? 255 : 255 * ((Math.Asin((_startingY - y) / dist) + Math.PI / 2) / Math.PI);
            //var green = (_startingY - y) == 0 ? 255 : 255 * (Math.Atan((_startingX - x) / (_startingY - y)) + Math.PI/2) / Math.PI;
            var blue = redBlock % 256;
            return Color.FromArgb(red, (int)green, 0);
        }
    }
}
