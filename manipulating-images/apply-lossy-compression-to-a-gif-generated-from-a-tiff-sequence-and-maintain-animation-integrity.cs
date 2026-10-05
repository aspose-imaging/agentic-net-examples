// HOW-TO: Compress Multi‑Page TIFF to Animated GIF with Reduced Color Depth in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (handle possible null)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Configure GIF options with reduced color resolution for lossy compression
                var gifOptions = new GifOptions
                {
                    // Reduce color depth to 8 bits per pixel (lossy)
                    ColorResolution = 8
                };

                // Save as animated GIF while preserving frames and timing
                tiffImage.Save(outputPath, gifOptions);
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
 * 1. When you need to shrink a multi‑page scanned document into a smaller animated GIF for web preview while accepting some color loss.
 * 2. When you want to generate lightweight animated product demos from high‑resolution TIFF sequences for email newsletters.
 * 3. When you must convert medical imaging TIFF stacks into GIFs with reduced file size for quick sharing between clinicians.
 * 4. When you are building a C# application that archives time‑lapse photography by turning TIFF frames into a compressed animated GIF.
 * 5. When you need to automate batch processing of TIFF animations into GIFs with 8‑bit color to meet bandwidth constraints on mobile apps.
 */
