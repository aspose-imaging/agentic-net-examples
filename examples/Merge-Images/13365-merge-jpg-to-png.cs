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
        // Input JPEG image paths
        List<string> imagePaths = new List<string>
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        // Prepare output PNG options with file source
        string outputPath = "merged_output.png";
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = outputSource };

        // Create PNG canvas
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Merge each JPEG onto the canvas
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output path already bound in options)
            canvas.Save();
        }
    }
}