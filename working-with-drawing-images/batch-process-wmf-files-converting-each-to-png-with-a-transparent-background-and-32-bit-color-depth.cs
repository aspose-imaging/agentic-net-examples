// HOW-TO: Batch Convert WMF to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "InputWmf";
            string outputDir = "OutputPng";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all WMF files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.wmf");

            foreach (var inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
                {
                    // Configure rasterization options with transparent background
                    WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = wmf.Size
                    };

                    // Set PNG options for 32‑bit color depth (Truecolor with Alpha)
                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PNG
                    wmf.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a library of legacy WMF icons into high‑quality PNGs with alpha transparency for use in modern web applications.
 * 2. When an automated build process must rasterize vector WMF diagrams into 32‑bit PNG files to embed them in PDF reports.
 * 3. When a desktop application requires batch exporting of user‑drawn WMF charts to transparent PNGs for seamless overlay on other graphics.
 * 4. When migrating a Windows‑based asset pipeline, you need to replace WMF logos with PNG equivalents that preserve transparency across platforms.
 * 5. When generating thumbnails of WMF files for a content‑management system, you want each thumbnail saved as a PNG with a transparent background for consistent UI styling.
 */
