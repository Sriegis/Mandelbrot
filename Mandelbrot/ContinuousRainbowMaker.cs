using System;
using System.Drawing;

namespace Mandelbrot
{
    public class ContinuousRainbowMaker : IRainbowMaker
    {
        private readonly double _scaleFactorX;
        private readonly double _scaleFactorY;
        private readonly double _dimX;
        private readonly double _dimY;

        public ContinuousRainbowMaker(int dimX, int dimY)
        {
            _dimX = dimX;
            _dimY = dimY;
            _scaleFactorX = (double)dimX / 256; // kiek pikseliu gali buti spausdinami is eiles nekeitus ju vertes
            _scaleFactorY = (double)dimY / 256;
        }

        public Color GetPixelColor(int x, int y)
        {
            var xBlock = (int) (x / _scaleFactorX); // todo: debug
            var yBlock = (int) (y / _scaleFactorY);
            return Color.FromArgb(xBlock, yBlock, Math.Min((xBlock + 16 * yBlock), 255) );
        }
    }
}
