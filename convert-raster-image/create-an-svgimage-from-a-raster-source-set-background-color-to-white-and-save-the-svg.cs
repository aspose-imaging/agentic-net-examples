// HOW-TO: Convert PNG to SVG with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG output
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set background color to white
                    BackgroundColor = Aspose.Imaging.Color.White,
                    // Use the size of the source image as the page size
                    PageSize = image.Size
                };

                // Create SVG save options and attach rasterization options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster logo in a web page as scalable SVG while ensuring a solid white background.
 * 2. When converting scanned PNG diagrams to SVG for printing on white paper without transparent artifacts.
 * 3. When generating SVG assets from user‑uploaded PNG images in a C# application that requires consistent background color.
 * 4. When creating vector‑compatible versions of PNG icons for responsive UI designs using Aspose.Imaging.
 * 5. When automating batch processing of PNG files to SVG format with predefined page size and white background in .NET.
 */
