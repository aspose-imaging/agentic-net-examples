// HOW-TO: Set SVG Raster Page Size In Inches For PNG Output In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

                // Specify page size in inches (e.g., 4 inches wide by 3 inches high)
                rasterOptions.PageSize = new SizeF(4.0f, 3.0f);

                // Optional: set background color
                rasterOptions.BackgroundColor = Color.White;

                // Prepare PNG save options and set DPI via ResolutionSettings
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(96, 96) // 96 DPI
                };

                // Save the rasterized image
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to convert an SVG logo to a PNG of a specific physical size for print materials.
 * 2. When generating thumbnails that must match exact dimensions in inches for a PDF report.
 * 3. When creating UI assets where the rasterized image must align with a design system's inch‑based layout grid.
 * 4. When exporting SVG diagrams to PNG at a known DPI to ensure consistent scaling across different devices.
 * 5. When automating batch processing of SVG files to produce print‑ready PNGs with precise width and height specifications.
 */
