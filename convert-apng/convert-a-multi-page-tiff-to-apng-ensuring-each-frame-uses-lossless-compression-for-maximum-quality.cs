using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.apng";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options for lossless compression
                var apngOptions = new ApngOptions
                {
                    // Default frame duration (in milliseconds); adjust as needed
                    DefaultFrameTime = 100,
                    // PNG compression level (0 = no compression, still lossless)
                    PngCompressionLevel = 0
                };

                // Save as APNG
                image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to convert a multi‑page TIFF scanned document into a high‑quality animated PNG for web preview without losing any image detail.
 * 2. When an application must generate lossless animated graphics from a series of TIFF frames for inclusion in a mobile app’s onboarding tutorial.
 * 3. When a digital archiving system requires transforming multi‑page TIFF medical images into APNG format to enable smooth frame‑by‑frame navigation in a browser.
 * 4. When a game developer wants to create sprite animations from TIFF assets while preserving exact colors using C# and Aspose.Imaging’s lossless PNG compression.
 * 5. When an e‑learning platform needs to programmatically convert multi‑page TIFF lecture slides into an animated PNG that can be streamed with consistent frame timing.
 */