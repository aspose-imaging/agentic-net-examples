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
        string inputPath = @"c:\temp\test.webp";
        string outputPath = @"c:\temp\test.output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as PNG
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                webPImage.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to convert user‑uploaded WebP avatars to PNG for compatibility with older browsers, the code checks the file’s existence before conversion.
 * 2. When an automated image‑processing pipeline processes a batch of WebP assets and must avoid FileNotFound exceptions, the snippet validates each input path prior to saving as PNG.
 * 3. When a desktop utility converts WebP screenshots to PNG for printing, it first ensures the source file exists to prevent runtime errors.
 * 4. When a cloud function receives a WebP image URL, downloads it to a temporary folder, and then transforms it to PNG, the code’s existence check safeguards against missing downloads.
 * 5. When a content‑management system migrates legacy WebP graphics to PNG for archival, the program verifies the source file before performing the format conversion.
 */