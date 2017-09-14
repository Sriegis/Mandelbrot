using System.Drawing;

namespace Mandelbrot
{
    public interface IRainbowMaker
    {
        Color GetPixelColor(int x, int y);
    }
}
