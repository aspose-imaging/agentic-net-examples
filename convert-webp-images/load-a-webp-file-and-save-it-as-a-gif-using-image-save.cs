// HOW-TO: Convert WebP Image to GIF Using Aspose.Imaging Save Method in C# (Aspose.Imaging for .NET)
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
 * 1. When you need to display a WebP graphic on a platform that only supports GIF animations.
 * 2. When you are generating email newsletters and must embed images as GIFs for compatibility with older email clients.
 * 3. When you want to create a lightweight animated preview by converting a WebP sequence into a GIF for web pages.
 * 4. When you are migrating a legacy asset library and need to batch‑convert WebP files to GIF for a Windows application that reads only GIFs.
 * 5. When you need to extract a single frame from a WebP file and save it as a GIF for use in documentation or reports.
 */
