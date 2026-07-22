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
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Flip the image horizontally
                webPImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save the transformed image as BMP
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
 * 1. When a developer needs to convert a WebP image to BMP format and flip it horizontally for a legacy Windows application that only accepts BMP files.
 * 2. When a developer must generate a mirrored thumbnail of a WebP photo for a web gallery that stores thumbnails as BMP for faster rendering on older browsers.
 * 3. When a developer wants to preprocess user‑uploaded WebP graphics by horizontally flipping them and saving as BMP to meet a printing service’s file‑format requirements.
 * 4. When a developer is building an automated batch job that normalizes image orientation by flipping WebP assets and converts them to BMP for compatibility with a third‑party image analysis tool.
 * 5. When a developer needs to integrate image transformation in a C# utility that reads WebP files, applies a horizontal flip, and outputs BMP files for use in a Windows‑only reporting system.
 */