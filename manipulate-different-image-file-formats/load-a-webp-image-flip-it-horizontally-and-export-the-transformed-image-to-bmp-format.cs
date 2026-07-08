using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

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

            // Load WebP image, flip horizontally, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Horizontal flip (no rotation)
                webPImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

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
 * 1. When a developer must convert a WebP logo uploaded by a client into a BMP file while mirroring it horizontally for use in a legacy Windows desktop application.
 * 2. When an e‑commerce platform needs to generate BMP product images from WebP assets and display them flipped to match a right‑to‑left language layout.
 * 3. When a photo‑editing tool requires loading a WebP picture, applying a horizontal flip, and saving the result as BMP to maintain compatibility with older image viewers.
 * 4. When an automated batch process has to read WebP screenshots, reverse their orientation, and export them as BMP files for archival in a corporate document management system.
 * 5. When a game development pipeline needs to import WebP textures, flip them horizontally, and output BMP files for use with a legacy rendering engine that only supports BMP format.
 */