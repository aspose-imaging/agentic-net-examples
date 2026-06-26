using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with maximum lossless compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9 // 0-9, 9 = maximum compression
                };

                // Set rasterization options required for vector images like ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a C#‑based web application needs to generate lightweight PNG thumbnails from OpenDocument graphics (ODG) for faster page loads, it can use this code to convert and apply maximum lossless compression.
 * 2. When an automated reporting service written in C# must embed vector drawings from LibreOffice ODG files into PDF or HTML outputs, the code converts the ODG to PNG while preserving quality and minimizing size.
 * 3. When a desktop C# application processes user‑uploaded ODG diagrams and stores them as PNG assets in a database, using the highest PNG compression level reduces storage requirements.
 * 4. When a batch‑processing C# service migrates legacy ODG assets to a cloud image CDN, converting each file to PNG with lossless compression ensures quick delivery and cache efficiency.
 * 5. When a C# microservice creates preview images for an e‑learning platform that stores course illustrations as ODG, the code produces PNG previews with maximum compression for rapid display without quality loss.
 */