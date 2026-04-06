using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Validate each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists before any save operation
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string inputPath in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal concatenation
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create PNG canvas bound to the output file
        Source fileSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = fileSource };

        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    // Copy pixels from the source image to the canvas at the current offset
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output path already set via FileCreateSource)
            canvas.Save();
        }
    }
}