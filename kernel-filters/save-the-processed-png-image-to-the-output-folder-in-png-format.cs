// HOW-TO: Convert BMP to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set PNG save options (default options are sufficient)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform legacy BMP assets into web‑friendly PNG files for faster page loads.
 * 2. When an automated build script must convert scanned BMP images to lossless PNG format before publishing.
 * 3. When a desktop application processes user‑uploaded BMP pictures and stores them as PNG to reduce file size.
 * 4. When a migration tool replaces BMP icons with PNG equivalents to support modern UI frameworks.
 * 5. When a reporting service generates charts as BMP and then saves them as PNG for inclusion in PDF documents.
 */
