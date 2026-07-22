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

            // Load the WebP image, apply a 180-degree rotation, and save as BMP
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate 180 degrees, resize proportionally, use white background for any empty areas
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
 * 1. When a developer needs to read a WebP image, rotate it 180 degrees, and save it as a BMP file for compatibility with older Windows printing pipelines.
 * 2. When an e‑commerce platform stores product photos in WebP to save bandwidth but must supply BMP versions rotated for a third‑party catalog that expects images upright.
 * 3. When a desktop application imports user‑provided WebP graphics, applies a 180° rotation to correct orientation, and writes the result to BMP for use in a legacy reporting module.
 * 4. When a batch‑processing script must convert a folder of WebP icons to BMP while flipping each icon vertically to match a UI design guideline.
 * 5. When a server‑side C# service receives WebP screenshots, rotates them 180 degrees to align with a mirrored display, and stores them as BMP for archival in a format that does not support WebP.
 */