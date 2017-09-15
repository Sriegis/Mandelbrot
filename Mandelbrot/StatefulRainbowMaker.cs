using System.Drawing;

namespace Mandelbrot
{
    public class StatefulRainbowMaker : IRainbowMaker
    {
        private Color _lastColor;

        public StatefulRainbowMaker()
        {
            _lastColor = new Color();
            
        }

        public Color GetPixelColor(int x, int y)
        {
            return IncrementColor();
        }

        private Color IncrementColor()
        {
            var r = _lastColor.R;
            var g = _lastColor.G;
            var b = _lastColor.B;

            if (r < 255)
            {
                r++;
            }
            else if (g < 255)
            {
                g++;
                r = 0;
            }
            else if (b < 255)
            {
                b++;
                g = 0;
                r = 0;
            }
            else
            {
                r = 0;
                g = 0;
                b = 0;
            }

            var color = Color.FromArgb(r, g, b);
            _lastColor = color;

            return color;
        }
    }
}