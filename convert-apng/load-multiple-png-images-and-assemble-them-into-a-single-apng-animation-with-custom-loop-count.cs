using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG file paths
        string[] inputPaths = { "image1.png", "image2.png", "image3.png" };
        // Hardcoded output APNG file path
        string outputPath = "output/animation.apng";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Validate each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Load first image to obtain canvas size (assumes all images share the same dimensions)
        int canvasWidth;
        int canvasHeight;
        using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Create APNG options with custom loop count and default frame time
        ApngOptions options = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = PngColorType.TruecolorWithAlpha,
            NumPlays = 5,                     // Custom loop count (0 = infinite)
            DefaultFrameTime = 100            // Frame duration in milliseconds
        };

        // Create APNG canvas and add each PNG as a frame
        using (ApngImage apng = (ApngImage)Image.Create(options, canvasWidth, canvasHeight))
        {
            // Remove the default single frame
            apng.RemoveAllFrames();

            foreach (string path in inputPaths)
            {
                using (RasterImage frame = (RasterImage)Image.Load(path))
                {
                    apng.AddFrame(frame);
                }
            }

            // Save the assembled APNG animation
            apng.Save();
        }
    }
}