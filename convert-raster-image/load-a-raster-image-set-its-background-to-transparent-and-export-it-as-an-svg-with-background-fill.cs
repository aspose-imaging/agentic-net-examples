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
        string inputPath = "input.png";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the raster image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Prepare SVG save options with transparent background
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Set background to transparent
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        // Use the original image size as page size
                        PageSize = rasterImage.Size
                    }
                };

                // Save as SVG
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert product PNG images into scalable SVG icons for responsive web design while keeping the background transparent.
 * 2. When generating vector graphics from scanned raster documents and the resulting SVG must have a transparent canvas for overlay in presentations.
 * 3. When preparing logo assets by transforming original PNG files into SVG format without any background fill for clean print and digital use.
 * 4. When creating SVG map layers from raster tile images and the background must be set to transparent to allow seamless stacking with other map data.
 * 5. When automating batch conversion of UI screenshots to SVG for technical documentation, ensuring each SVG retains a transparent background.
 */