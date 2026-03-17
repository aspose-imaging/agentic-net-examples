using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image file paths (replace with actual paths or streams as needed)
        string[] inputPaths = new string[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        // Output combined image path
        string outputPath = "combined.png";

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal concatenation
        int newWidth = 0;
        int newHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        // Create a file source for the output image
        Source fileSource = new FileCreateSource(outputPath, false);

        // Set PNG options with the file source
        PngOptions pngOptions = new PngOptions() { Source = fileSource };

        // Create a blank canvas with the calculated dimensions
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;

            // Merge each image onto the canvas side by side
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas to the output file
            canvas.Save();
        }
    }
}