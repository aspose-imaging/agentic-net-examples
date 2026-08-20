// HOW-TO: Batch Convert SVG Files To 24‑Bit BMP Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputBmps";

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output BMP path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set rasterization options for vector image
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    // Configure BMP save options with 24‑bit depth
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save as BMP
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate high‑quality 24‑bit BMP thumbnails from a collection of SVG icons for a Windows desktop application.
 * 2. When a legacy system only accepts BMP files, and you must programmatically transform a folder of vector SVG assets into compatible raster images.
 * 3. When automating the preparation of print‑ready bitmap graphics from scalable SVG designs in a build pipeline.
 * 4. When creating a batch conversion tool to migrate SVG artwork to BMP format for use in older game engines that require 24‑bit bitmaps.
 * 5. When processing user‑uploaded SVG files on a server and storing them as BMPs with a white background for consistent rendering across browsers.
 */
