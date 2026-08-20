// HOW-TO: Convert SVG to BMP with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.svg";
        string outputPath = "Output\\sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with 300 DPI resolution
                BmpOptions bmpOptions = new BmpOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate high‑resolution bitmap thumbnails from vector SVG assets for printing or PDF embedding.
 * 2. When a desktop application must export user‑drawn SVG diagrams as BMP files with a fixed 300 DPI for compatibility with legacy imaging software.
 * 3. When an automated build pipeline converts SVG icons to BMP format at 300 DPI to meet a corporate style guide that requires raster images for documentation.
 * 4. When a reporting tool rasterizes scalable SVG charts into BMP images at 300 DPI to ensure consistent sizing across different monitors and printers.
 * 5. When a migration script replaces SVG logos with BMP equivalents while preserving exact physical dimensions by setting the resolution explicitly.
 */
