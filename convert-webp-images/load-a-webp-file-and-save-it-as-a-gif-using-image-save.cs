using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image and save as GIF
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                webPImage.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to convert user‑uploaded WebP images to GIF for compatibility with legacy browsers that only support GIF animation.
 * 2. When an e‑commerce platform must generate GIF thumbnails from product photos stored as WebP to embed in email newsletters.
 * 3. When a mobile app backend processes WebP screenshots and saves them as GIF to create lightweight animated previews for social media sharing.
 * 4. When a content management system migrates archived WebP assets to GIF to ensure they can be displayed in older Windows applications that rely on System.Drawing.
 * 5. When a batch‑processing script converts a folder of WebP graphics to GIF format to comply with a third‑party API that accepts only GIF files.
 */