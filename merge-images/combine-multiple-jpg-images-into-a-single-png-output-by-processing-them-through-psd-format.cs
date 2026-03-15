using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        List<string> jpgPaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        List<Size> sizes = new List<Size>();
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        PsdOptions psdOptions = new PsdOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(psdOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource("output.png", false)
            };
            canvas.Save("output.png", pngOptions);
        }
    }
}