// HOW-TO: Convert PNG to SVG with Light Gray Background in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

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
                // Prepare SVG save options with background color
                SvgOptions svgOptions = new SvgOptions();

                // Configure rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Set background color to light gray
                    BackgroundColor = Aspose.Imaging.Color.LightGray,
                    // Set page size to match the source image
                    PageSize = image.Size
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG with the specified options
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
 * 1. When you need to embed a PNG logo into a web page as scalable SVG while ensuring a consistent light‑gray canvas behind it.
 * 2. When generating vector graphics from scanned photos for print layouts and you want a uniform background color to avoid transparency issues.
 * 3. When converting UI screenshots to SVG for responsive design and you must replace transparent areas with a light gray fill.
 * 4. When creating SVG assets from raster icons for a mobile app and you need the background color set programmatically using Aspose.Imaging in C#.
 * 5. When automating batch processing of product images to SVG format and require a specific background shade to match brand guidelines.
 */
