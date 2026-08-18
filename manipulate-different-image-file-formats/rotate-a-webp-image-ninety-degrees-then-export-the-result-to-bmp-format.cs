// HOW-TO: Rotate WebP Image 90 Degrees and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image, rotate 90 degrees clockwise, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                webPImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save to BMP format
                webPImage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to display a WebP graphic in a legacy Windows application that only supports BMP, you can rotate it and convert it to BMP using C#.
 * 2. When processing user‑uploaded WebP photos taken in portrait mode, you may rotate them 90° and save as BMP for further analysis.
 * 3. When generating thumbnails for a reporting system that requires BMP files, you can rotate the original WebP image before conversion.
 * 4. When integrating with a third‑party library that only accepts BMP images, you can pre‑rotate a WebP asset to the correct orientation in C#.
 * 5. When preparing images for printing on devices that require BMP format and specific orientation, you can rotate the WebP file and export it as BMP.
 */
