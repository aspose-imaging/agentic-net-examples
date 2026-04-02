using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = "output.png";

        // Verify input files exist
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load, flip, and collect images
        List<RasterImage> images = new List<RasterImage>();
        int totalWidth = 0;
        int maxHeight = 0;

        foreach (string path in inputPaths)
        {
            RasterImage img = (RasterImage)Image.Load(path);
            img.RotateFlip(RotateFlipType.RotateNoneFlipX);
            images.Add(img);
            totalWidth += img.Width;
            if (img.Height > maxHeight) maxHeight = img.Height;
        }

        // Create PNG canvas bound to output file
        Source outSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (RasterImage img in images)
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetX += img.Width;
            }

            // Save the bound canvas
            canvas.Save();
        }

        // Dispose loaded images
        foreach (RasterImage img in images)
        {
            img.Dispose();
        }
    }
}