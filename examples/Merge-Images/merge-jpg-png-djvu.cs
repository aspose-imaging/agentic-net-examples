using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "merged.png";

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        using (RasterImage jpg = (RasterImage)Image.Load(jpgPath))
        {
            sizes.Add(jpg.Size);
        }
        using (RasterImage png = (RasterImage)Image.Load(pngPath))
        {
            sizes.Add(png.Size);
        }

        // Calculate canvas size for horizontal merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create PNG canvas
        Source src = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = src };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally
            int offsetX = 0;
            foreach (string path in new[] { jpgPath, pngPath })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged image (bound canvas)
            canvas.Save();
        }
    }
}