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
            string inputPath = @"C:\Images\input.webp";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image, rotate hue by 180 degrees, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate the image 180 degrees (geometric rotation)
                webPImage.Rotate(180f, true, Aspose.Imaging.Color.White);

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
 * 1. When a developer needs to convert WebP graphics received from a web service into BMP files for a legacy Windows desktop application that only supports BMP, while also inverting the colors by rotating the hue 180° using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform stores product photos in WebP to save bandwidth but must generate BMP thumbnails for a third‑party catalog printer that requires BMP input, and the color scheme must be flipped by a 180° hue rotation.
 * 3. When a game engine imports user‑uploaded WebP textures but the engine’s older rendering pipeline only accepts BMP assets, and the developer wants to apply a 180° hue shift to create a night‑mode version of the texture.
 * 4. When a medical imaging system receives scanned diagrams in WebP format and needs to export them as BMP for integration with legacy analysis software, applying a 180° hue rotation to correct the color polarity.
 * 5. When an automated batch job processes WebP icons for a corporate intranet, converting them to BMP for compatibility with older Windows servers and using a 180° hue rotation to match a dark theme across the site.
 */