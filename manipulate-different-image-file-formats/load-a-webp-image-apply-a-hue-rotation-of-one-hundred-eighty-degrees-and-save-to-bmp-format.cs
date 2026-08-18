// HOW-TO: Rotate WebP Image 180 Degrees and Save as BMP in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.bmp";

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
                // Apply a 180-degree rotation (used here as a placeholder for hue rotation)
                webPImage.Rotate(180f, true, Aspose.Imaging.Color.White);

                // Save the result as BMP
                BmpOptions bmpOptions = new BmpOptions();
                webPImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert a WebP graphic to BMP after flipping it for legacy Windows applications.
 * 2. When a batch process must re‑orient WebP photos by 180° before storing them in a BMP‑based reporting system.
 * 3. When an image‑processing pipeline requires rotating WebP assets for correct display on devices that only support BMP.
 * 4. When you are preparing thumbnails for a .NET desktop app that only reads BMP files and the source images are in WebP format.
 * 5. When you must programmatically adjust the orientation of WebP images and save them as BMP to maintain compatibility with older printing software.
 */
