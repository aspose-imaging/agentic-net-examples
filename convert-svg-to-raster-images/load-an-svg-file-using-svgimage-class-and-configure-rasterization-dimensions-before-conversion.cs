// HOW-TO: Convert SVG to PNG with Custom Dimensions Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\test.svg";
        string outputPath = @"C:\temp\test.output.png";

        try
        {
            // Verify that the input SVG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from the file system
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Configure rasterization options (set desired output dimensions)
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Example: rasterize to 800 × 600 pixels
                    PageSize = new Size(800, 600),

                    // Optional: adjust scaling factors if needed
                    // ScaleX = 1.0f,
                    // ScaleY = 1.0f
                };

                // Prepare PNG save options and attach the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create 800 × 600 PNG thumbnails from SVG icons for a web gallery using C# and Aspose.Imaging.
 * 2. When an automated report generator must embed high‑resolution PNG versions of SVG logos into PDFs, requiring custom rasterization dimensions.
 * 3. When a batch‑processing service converts user‑uploaded SVG files into uniformly sized PNG assets for a mobile app with C# code.
 * 4. When a CI pipeline validates that SVG assets render correctly by rasterizing them to PNG at a fixed pixel size during build.
 * 5. When a desktop application previews SVG drawings as raster images with exact width and height before printing or saving.
 */
