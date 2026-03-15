using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG image paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output PNG path
        string outputPath = "combined.png";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Prepare PNG options with bound output file
        Source src = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = src };

        // Create canvas image bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the combined image (file is already bound)
            canvas.Save();
        }
    }
}