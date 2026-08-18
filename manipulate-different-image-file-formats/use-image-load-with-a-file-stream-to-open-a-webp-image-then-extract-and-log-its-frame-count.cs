// HOW-TO: How to Load WebP Image from Stream and Get Frame Count in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"c:\temp\test.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open a file stream and load the image using Image.Load
            using (FileStream stream = File.OpenRead(inputPath))
            {
                Image image = Image.Load(stream);

                // Cast to WebPImage to access PageCount (frame count)
                if (image is WebPImage webPImage)
                {
                    Console.WriteLine($"Frame count: {webPImage.PageCount}");
                }
                else
                {
                    Console.WriteLine("The loaded image is not a WebP image.");
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
 * 1. When you need to verify the number of frames in an animated WebP file before processing or converting it.
 * 2. When building a server‑side service that reads uploaded WebP images via streams and logs their animation length for analytics.
 * 3. When creating a batch tool that scans a directory of WebP assets to ensure each file contains the expected frame count for quality control.
 * 4. When integrating Aspose.Imaging into a C# application that must read WebP images from a network stream without loading the whole file into memory.
 * 5. When debugging image‑processing pipelines and you want to output the frame count of a WebP image to confirm correct loading.
 */
