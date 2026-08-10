// HOW-TO: Flip WebP Image Horizontally and Save as BMP in C# (Aspose.Imaging for .NET)
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
 * 1. When you need to convert user‑uploaded WebP graphics to BMP for legacy Windows applications while mirroring the image for a right‑to‑left layout.
 * 2. When generating thumbnails for a printing pipeline that requires BMP files and the source assets are stored as WebP, and the design calls for a horizontal flip.
 * 3. When processing scanned documents saved as WebP and you must flip them to correct orientation before saving them in BMP for OCR tools that only accept BMP input.
 * 4. When creating assets for a game engine that only supports BMP textures, and you have to mirror WebP sprites horizontally during the import process.
 * 5. When automating batch conversion of WebP icons to BMP format for a desktop UI, ensuring each icon is flipped to match the UI’s mirrored theme.
 */
