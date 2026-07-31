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
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

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
                // Prepare SVG export options with grayscale color mode
                var svgExportOptions = new SvgOptions
                {
                    ColorType = SvgColorMode.Grayscale
                };

                // Rasterization options required for PNG conversion
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgExportOptions.VectorRasterizationOptions = rasterOptions;

                // PNG save options using the same rasterization settings
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized grayscale image as PNG
                image.Save(outputPath, pngSaveOptions);
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
 * 1. When a web application uses Aspose.Imaging for .NET to generate grayscale thumbnails from user‑uploaded SVG logos and save them as PNG files for faster page loads.
 * 2. When an automated reporting service needs to convert vector diagrams in SVG format to monochrome PNG images with Aspose.Imaging’s rasterization options for inclusion in printable PDF reports.
 * 3. When a desktop utility processes a batch of SVG icons, applies a grayscale color matrix via Aspose.Imaging, and exports them to PNG to match a dark‑mode UI theme.
 * 4. When a CI/CD pipeline validates that SVG assets are correctly rendered in grayscale by rasterizing them to PNG with Aspose.Imaging for visual regression testing.
 * 5. When a mobile app backend prepares low‑contrast PNG assets from SVG illustrations using Aspose.Imaging’s grayscale export to improve accessibility for users with visual sensitivities.
 */