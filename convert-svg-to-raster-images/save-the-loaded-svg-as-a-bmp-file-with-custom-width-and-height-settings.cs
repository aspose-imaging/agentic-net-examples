using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Define custom rasterization size
                int customWidth = 800;   // desired bitmap width
                int customHeight = 600;  // desired bitmap height

                // Configure BMP save options with vector rasterization settings
                BmpOptions bmpOptions = new BmpOptions
                {
                    // Set rasterization options to control the output size
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(customWidth, customHeight)
                    }
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, bmpOptions);
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
 * 1. When a web application must generate thumbnail previews of user‑uploaded SVG icons as BMP files with a fixed 800×600 size for legacy Windows components.
 * 2. When a desktop reporting tool needs to embed vector graphics from SVG files into a BMP‑based PDF template, requiring precise raster dimensions to align with the layout grid.
 * 3. When an automated batch process converts a library of SVG logos into BMP assets for a game engine that only supports bitmap textures of specific resolution.
 * 4. When a document‑generation service must render scalable SVG diagrams as BMP images at a custom width and height to meet print‑ready specifications.
 * 5. When a migration script rewrites legacy SVG assets into BMP format for an older Windows application that cannot handle vector formats, ensuring each image matches the required screen resolution.
 */