// HOW-TO: Batch Convert Multiple SVG Files to BMP Using Shared Raster Options in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG files (modify as needed)
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.svg",
                @"C:\Images\sample2.svg",
                @"C:\Images\sample3.svg"
            };

            // Create a single SvgRasterizationOptions instance to be reused
            var rasterOptions = new SvgRasterizationOptions();

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output BMP path (same folder, .bmp extension)
                string outputPath = Path.ChangeExtension(inputPath, ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure BMP options with the shared rasterization options
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterOptions
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
 * 1. When you need to generate bitmap thumbnails from a set of SVG icons for a Windows desktop application.
 * 2. When you must prepare BMP assets for legacy hardware that only supports raster images, converting many SVG logos at once.
 * 3. When automating a build pipeline that transforms design SVG files into BMP resources for a game engine.
 * 4. When creating printable BMP versions of vector diagrams in bulk for a reporting system that only accepts BMP input.
 * 5. When migrating a web project's SVG assets to BMP format for compatibility with a third‑party imaging service that requires raster files.
 */
