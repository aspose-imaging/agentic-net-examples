// HOW-TO: Convert WebP Image to GIF from Memory Stream in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

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

            // Load WebP image from a memory stream
            byte[] webpData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(webpData))
            using (WebPImage webPImage = new WebPImage(ms))
            {
                // Save as GIF
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
 * 1. When you need to display a WebP graphic on a legacy website that only supports GIF, you can convert the image directly from a byte array in memory using C#.
 * 2. When processing uploaded user images in a web API, you can transform WebP uploads to GIF for email attachments without writing temporary files to disk.
 * 3. When generating animated thumbnails from WebP sources in a server‑side batch job, you can load the data into a MemoryStream and save it as GIF to reduce I/O overhead.
 * 4. When integrating with a third‑party service that returns WebP data via a stream, you can instantly convert that stream to a GIF for compatibility with older mobile apps.
 * 5. When building a desktop utility that batch‑converts WebP files to GIF while preserving folder structure, using a memory‑stream conversion avoids cluttering the filesystem with intermediate files.
 */
