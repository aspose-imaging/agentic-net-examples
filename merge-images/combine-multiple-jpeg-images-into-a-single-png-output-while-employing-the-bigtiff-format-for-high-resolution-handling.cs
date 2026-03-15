using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "merged_output.png";

        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(new Size(img.Width, img.Height));
            }
        }

        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        Source src = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = src };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    canvas.SaveArgb32Pixels(bounds, pixels);
                    offsetX += img.Width;
                }
            }
            canvas.Save();
        }
    }
}