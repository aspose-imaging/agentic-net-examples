// HOW-TO: Convert OTG to PNG with Anti‑Aliasing Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths (relative)
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure OTG rasterization options with anti-aliasing
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                // Set up PNG save options and assign the rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save the image as PNG with the configured options
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
 * 1. When you need to generate high‑quality PNG thumbnails from OTG vector drawings for web previews, enabling anti‑aliasing for smoother edges.
 * 2. When exporting CAD‑style OTG files to PNG for inclusion in documentation, and you want the rasterized image to retain crisp, smoothed lines.
 * 3. When building a batch conversion tool that processes OTG assets into PNG assets for a game engine, using anti‑aliasing to improve visual fidelity.
 * 4. When integrating Aspose.Imaging into a C# service that converts user‑uploaded OTG diagrams to PNG for email attachments, ensuring the output looks polished.
 * 5. When creating a reporting system that converts OTG schematics to PNG charts with anti‑aliasing to avoid jagged lines in printed reports.
 */
