// HOW-TO: Batch Convert Multiple SVG Files to PNG Using Shared Rasterization Options in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPngs";

            // Get all SVG files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.svg");

            // Prepare a reusable rasterization options instance
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Prepare PNG save options that will use the rasterization options
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set page size for current image (preserves aspect ratio if needed)
                    rasterizationOptions.PageSize = image.Size;

                    // Save as PNG using the shared options
                    image.Save(outputPath, pngSaveOptions);
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
 * 1. When you need to generate PNG thumbnails for a large collection of SVG icons in a web application.
 * 2. When you want to automate the conversion of vector graphics to raster images for printing or email attachments without recreating rasterization settings for each file.
 * 3. When you are building a CI/CD pipeline that validates SVG assets by converting them to PNG for visual regression testing.
 * 4. When you need to export SVG diagrams to PNG format for inclusion in PowerPoint presentations while preserving aspect ratios.
 * 5. When you are developing a desktop tool that processes user‑uploaded SVG files and saves them as PNGs using consistent rasterization parameters.
 */
