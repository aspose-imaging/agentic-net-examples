// HOW-TO: Compress GIF with Lossy Algorithm to Reduce File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.lossy.gif";

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

            // Load the source GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure lossy GIF options
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80,
                    // Optional: improve palette quality
                    DoPaletteCorrection = true
                };

                // Save the image with lossy compression
                using (FileStream outStream = File.OpenWrite(outputPath))
                {
                    image.Save(outStream, saveOptions);
                }
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
 * 1. When you need to shrink animated GIFs for faster web page loading using Aspose.Imaging’s lossy compression in C# without completely losing visual quality.
 * 2. When you want to reduce the size of GIF email attachments with Aspose.Imaging to stay under typical mailbox limits.
 * 3. When you are preparing GIF assets for a mobile app where bandwidth and storage are limited and you need C# code to apply lossy compression.
 * 4. When you need to batch‑process user‑uploaded GIFs on a server with Aspose.Imaging to meet CDN size constraints.
 * 5. When you want to generate lower‑resolution preview GIFs for product catalogs while keeping the original animation using C# and Aspose.Imaging.
 */
