using System.Drawing;

namespace Mandelbrot
{
    public class SquareRainbowMaker : IRainbowMaker
    {
        public Color GetPixelColor(int x, int y)
        {
            var xBox = x / 256;
            var yBox = y / 256;
            return Color.FromArgb(x % 256, y % 256, (16 * xBox + yBox) % 256);
        }
    }
}
