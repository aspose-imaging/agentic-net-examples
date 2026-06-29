using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

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

            // Load the PNG image
            using (Image rasterImage = Image.Load(inputPath))
            {
                int width = rasterImage.Width;
                int height = rasterImage.Height;

                // Create an SVG image with the same dimensions
                using (SvgImage svgImage = new SvgImage(width, height))
                {
                    // Set viewbox (page size) to match original dimensions via SvgOptions
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = new Size(width, height)
                        }
                    };

                    // Save the SVG file
                    svgImage.Save(outputPath, svgOptions);
                }
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
 * 1. When a developer needs to convert a raster PNG file to a scalable SVG for responsive web design while preserving the original image dimensions.
 * 2. When an application must generate vector graphics from user‑uploaded PNGs so they can be resized without loss of quality in C#.
 * 3. When a batch‑processing tool has to automate the transformation of PNG assets into SVG files with matching viewbox settings for printing workflows.
 * 4. When a .NET service needs to store images in a lightweight, XML‑based format like SVG to reduce bandwidth while keeping the exact width and height of the source PNG.
 * 5. When a graphics pipeline requires converting PNG screenshots into SVG vectors for further editing in vector‑editing software, ensuring the viewbox matches the original pixel size.
 */