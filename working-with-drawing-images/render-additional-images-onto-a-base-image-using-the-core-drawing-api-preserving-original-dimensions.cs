using System;
using Aspose.Imaging;

namespace ImageOverlayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseImagePath = args.Length > 0 ? args[0] : "base.png";
            string outputPath = args.Length > 1 ? args[1] : "output.png";
            string[] overlayPaths = args.Length > 2 ? args[2..] : new string[] { "overlay1.png", "overlay2.png" };

            using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
            {
                Graphics graphics = new Graphics(baseImage);
                foreach (string overlayPath in overlayPaths)
                {
                    using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                    {
                        graphics.DrawImage(overlay, new Point(0, 0));
                    }
                }
                baseImage.Save(outputPath);
            }
        }
    }
}