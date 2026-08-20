// HOW-TO: Save PSD as PNG with Anti‑Aliasing Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.psd";
        string outputPath = @"C:\temp\output.png";

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

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with high‑quality smoothing
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Enable anti‑aliasing for smoother edges
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                        // Optional: set a background color (white) for transparent areas
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to convert layered Photoshop files to PNG for web display while preserving smooth edges.
 * 2. When generating thumbnails from PSD assets for a gallery and want anti‑aliased borders.
 * 3. When exporting design mockups to PNG for client review and require high visual fidelity.
 * 4. When automating batch conversion of PSD files to PNG in a C# application and need consistent smoothing.
 * 5. When preparing PNG assets for printing or UI components where transparent areas should have a white background.
 */
