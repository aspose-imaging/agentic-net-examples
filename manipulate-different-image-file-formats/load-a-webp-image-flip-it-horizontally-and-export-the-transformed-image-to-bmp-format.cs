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
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\output.bmp";

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
                // Horizontal flip
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
 * 1. When a web application needs to convert user‑uploaded WebP avatars into BMP thumbnails while mirroring them for a left‑to‑right layout, a developer can use this C# code with Aspose.Imaging.
 * 2. When a legacy Windows desktop program only supports BMP files, but the source graphics are stored as WebP, the code enables a developer to load the WebP, flip it horizontally for correct orientation, and save it as BMP.
 * 3. When an e‑commerce site wants to display product images in a mirrored view for a special promotion, a developer can employ this snippet to read the WebP image, apply a horizontal flip, and export it to BMP for compatibility with older reporting tools.
 * 4. When a batch‑processing service must prepare WebP screenshots for a printing pipeline that requires BMP format and a mirrored layout, the code provides a straightforward C# solution using Aspose.Imaging’s RotateFlip method.
 * 5. When an automated testing framework validates image rendering by comparing expected BMP assets with transformed WebP inputs, a developer can use this example to load the WebP, flip it horizontally, and save the result as BMP for pixel‑perfect comparison.
 */