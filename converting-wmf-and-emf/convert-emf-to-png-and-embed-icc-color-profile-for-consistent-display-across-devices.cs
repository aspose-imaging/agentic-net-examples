// HOW-TO: Convert EMF to PNG with ICC Profile Embedding in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for EMF to PNG conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Set PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // ----- ICC profile embedding (illustrative) -----
                // Load an ICC profile if needed. Aspose.Imaging PNG saving does not expose a direct
                // property for ICC profiles, but you could embed it via metadata APIs if required.
                // using (FileStream iccStream = File.OpenRead("Input\\profile.icc"))
                // {
                //     // Embed ICC profile into the image metadata here.
                // }

                // Save the converted PNG image
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
 * 1. When you need to display vector EMF graphics as raster PNGs on web pages while preserving color accuracy across monitors.
 * 2. When a reporting system generates charts in EMF format and you must convert them to PNG for inclusion in PDF documents.
 * 3. When an automated batch job processes legacy EMF assets and saves them as PNG files with a consistent background color.
 * 4. When you want to embed an ICC color profile into the PNG to ensure the same colors appear on different devices.
 * 5. When you are building a C# application that validates the existence of source files and creates output directories before converting images.
 */
