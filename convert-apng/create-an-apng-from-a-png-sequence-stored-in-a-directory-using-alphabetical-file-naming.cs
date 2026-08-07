using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG sequence (alphabetical order) and output APNG path
        string[] inputPaths = new string[]
        {
            "frame1.png",
            "frame2.png",
            "frame3.png"
        };
        string outputPath = "output_animation.apng";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load the first image to obtain canvas size
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Prepare APNG creation options
                Source source = new FileCreateSource(outputPath, false);
                ApngOptions options = new ApngOptions
                {
                    Source = source,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100 // default frame duration in ms
                };

                // Create the APNG canvas
                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    // Remove the default single frame
                    apng.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            apng.AddFrame(frame);
                        }
                    }

                    // Save the APNG file
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to generate an animated PNG (APNG) from a series of sequentially named PNG files (e.g., frame1.png, frame2.png) for use in web banners or UI animations.
 * 2. When a C# application needs to combine individual PNG assets into a single APNG file with a consistent frame duration for cross‑platform mobile game sprites.
 * 3. When a reporting tool must convert a folder of chart images saved as PNG into an APNG slideshow that can be embedded in PDF or HTML reports.
 * 4. When an automated build pipeline has to create an APNG preview of image processing results by loading the first PNG to determine canvas size and then appending the rest as frames.
 * 5. When a developer is implementing a custom image export feature that saves a time‑lapse sequence of screenshots as an APNG using Aspose.Imaging’s ApngOptions and FileCreateSource.
 */