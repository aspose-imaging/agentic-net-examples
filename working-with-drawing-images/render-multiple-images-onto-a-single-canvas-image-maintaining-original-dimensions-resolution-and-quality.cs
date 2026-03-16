using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image file paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.png",
            "image3.bmp"
        };

        // Output canvas file path
        string outputPath = "merged.png";

        // Collect sizes of all input images
        List<Size> sizeList = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create output file source
        Source src = new FileCreateSource(outputPath, false);

        // Set PNG options (maintains quality)
        PngOptions pngOptions = new PngOptions { Source = src };

        // Create canvas image
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Draw each image onto the canvas
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas
            canvas.Save();
        }
    }
}