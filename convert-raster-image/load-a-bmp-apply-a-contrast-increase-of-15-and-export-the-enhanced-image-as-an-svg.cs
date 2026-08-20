// HOW-TO: Increase BMP Contrast By 15% And Save As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.svg";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Adjust contrast by 15%
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustContrast(15f);
                }

                // Save the enhanced image as SVG
                var svgOptions = new SvgOptions();
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
 * 1. When you need to improve the visual clarity of a legacy BMP graphic before converting it to a scalable SVG for responsive web design.
 * 2. When an application must batch‑process scanned BMP files, boost their contrast by a specific percentage, and store the results as lightweight SVG vectors.
 * 3. When generating printable diagrams from BMP assets where higher contrast is required and the final format must be resolution‑independent SVG.
 * 4. When integrating image enhancement into a C# workflow that reads BMP icons, adjusts their contrast, and outputs SVG icons for modern UI themes.
 * 5. When migrating desktop‑only BMP resources to a cross‑platform SVG format while ensuring the contrast levels meet branding guidelines.
 */
