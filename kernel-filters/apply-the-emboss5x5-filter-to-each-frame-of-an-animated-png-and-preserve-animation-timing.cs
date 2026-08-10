// HOW-TO: Apply Emboss5x5 Filter to Animated PNG Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\embossed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated PNG
            using (Image image = Image.Load(inputPath))
            {
                if (image is ApngImage apngImage)
                {
                    // Apply Emboss5x5 filter to each frame
                    for (int i = 0; i < apngImage.PageCount; i++)
                    {
                        // Each page is an ApngFrame which can be treated as RasterImage
                        var frame = (RasterImage)apngImage.Pages[i];
                        frame.Filter(
                            frame.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));
                    }

                    // Save the modified animation preserving timing
                    apngImage.Save(outputPath, new ApngOptions());
                }
                else
                {
                    Console.Error.WriteLine("The input file is not an animated PNG.");
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
 * 1. When you need to give an animated PNG a 3‑D embossed look while keeping its original frame delays.
 * 2. When you want to batch‑process each frame of an APNG to apply a convolution filter before publishing on a website.
 * 3. When you are building a C# desktop app that adds artistic effects to user‑uploaded animated stickers without breaking the animation timing.
 * 4. When you must generate a stylized version of a game sprite sheet stored as an animated PNG for use in a UI overlay.
 * 5. When you are creating an automated pipeline that converts raw APNG assets into embossed thumbnails for a media catalog while preserving animation speed.
 */
