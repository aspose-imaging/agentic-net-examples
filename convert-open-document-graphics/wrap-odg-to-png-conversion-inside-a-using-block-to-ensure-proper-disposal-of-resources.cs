// HOW-TO: Convert ODG Vector Image to PNG with Proper Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image and ensure proper disposal
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for vector to raster conversion
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Set PNG save options with the rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to transform OpenDocument Graphics (ODG) files into PNG thumbnails for web previews in a C# application.
 * 2. When you want to ensure memory is released by loading and saving images inside a using block while converting vector drawings to raster format.
 * 3. When you have to generate white‑background PNGs from ODG pages of varying sizes for reporting or documentation pipelines.
 * 4. When you must programmatically verify the source ODG exists and create the target folder before performing the conversion in an automated batch process.
 * 5. When you are integrating Aspose.Imaging into a .NET service that converts user‑uploaded ODG files to PNG for further image analysis or storage.
 */
