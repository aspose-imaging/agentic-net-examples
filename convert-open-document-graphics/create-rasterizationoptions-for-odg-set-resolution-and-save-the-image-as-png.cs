// HOW-TO: Convert ODG to PNG with Custom Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.png");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure rasterization options
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                // Configure PNG save options with resolution and source
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
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
 * 1. When you need to generate high‑resolution PNG thumbnails from ODG vector drawings for web preview.
 * 2. When an application must export OpenDocument graphics to PNG while preserving background color and page size.
 * 3. When a batch process converts ODG files to PNG with a specific DPI for printing purposes.
 * 4. When integrating Aspose.Imaging into a C# service that receives ODG uploads and returns PNG images at 300 dpi.
 * 5. When you want to programmatically rasterize ODG vector content with custom resolution before saving as PNG for further image processing.
 */
