using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.bmp";

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

            // Load the WebP image, rotate 90 degrees clockwise, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate 90 degrees without flipping
                webPImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the transformed image to BMP format
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
 * 1. When a web application needs to convert user‑uploaded WebP avatars into BMP thumbnails for legacy Windows components.
 * 2. When a desktop tool must rotate scanned WebP documents ninety degrees clockwise before saving them as BMP for compatibility with older printing software.
 * 3. When an e‑learning platform processes WebP graphics, rotates them to correct orientation, and exports them to BMP to embed in PowerPoint slides.
 * 4. When a game asset pipeline receives WebP textures, needs to re‑orient them and store them as BMP for a legacy engine that only supports BMP files.
 * 5. When an automated batch job validates image orientation, rotates WebP images, and converts them to BMP for archival in a system that requires uncompressed bitmap format.
 */