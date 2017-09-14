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

        //var dim = 4096;

        //var picture = new Bitmap(dim, dim);
        //var color = Color.Empty;
        //var xBox = 0;
        //var yBox = 0;

        //Console.WriteLine("Processing...");
        //for (var x = 0; x < picture.Width; x++)
        //{
        //    for (var y = 0; y < picture.Height; y++)
        //    {
        //        xBox = x / 256;
        //        yBox = y / 256;
        //        color = Color.FromArgb(x % 256, y % 256, 16*xBox + yBox);
        //        picture.SetPixel(x, y, color);
        //    }
        //}

        //Console.WriteLine("Done!");
        //picture.Save("Mandelbrot.bmp");
        //Console.ReadKey();
    }
}
