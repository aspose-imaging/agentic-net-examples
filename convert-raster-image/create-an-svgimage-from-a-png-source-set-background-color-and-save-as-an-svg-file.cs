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
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.svg";

        // Ensure any runtime exception is reported cleanly
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

            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options with a background color
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set desired background color
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    // Preserve original image size
                    PageSize = pngImage.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as SVG
                pngImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to embed a PNG logo into a responsive web page and wants to convert it to a scalable SVG with a light‑blue background for consistent rendering across browsers.
 * 2. When an automated build script must batch‑process PNG assets from a design folder and generate SVG versions with a predefined background color for use in vector‑based UI components.
 * 3. When a reporting tool creates charts as PNG images but the final PDF requires vector graphics, so the PNG is raster‑converted to SVG with a specific background to preserve appearance.
 * 4. When a mobile app loads PNG icons at runtime and the developer wants to cache them as SVG files with a uniform background to reduce memory usage and enable scaling.
 * 5. When a content management system imports user‑uploaded PNG pictures and needs to store them as SVG files with a set background color to maintain brand colors in all downstream publications.
 */