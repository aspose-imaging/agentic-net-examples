// HOW-TO: Convert WebP To PNG In C# With File Existence Check (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\test.webp";
            string outputPath = @"c:\temp\test.output.png";

            // Verify that the input WebP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as PNG
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                webPImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to safely transform user‑uploaded WebP graphics into PNGs for browsers that don’t support WebP.
 * 2. When a batch job processes image assets and must skip missing files to avoid runtime crashes.
 * 3. When generating thumbnails from WebP sources and you need to ensure the output folder exists before saving.
 * 4. When integrating Aspose.Imaging into a .NET service that converts WebP logos to PNG for printing pipelines.
 * 5. When building a migration script that validates source images before converting them to a lossless PNG format.
 */
