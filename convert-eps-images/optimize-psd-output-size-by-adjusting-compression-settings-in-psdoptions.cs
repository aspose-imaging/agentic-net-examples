// HOW-TO: How to Reduce PSD File Size Using RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options with RLE compression to reduce file size
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
                };

                // Save the image as PSD using the configured options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert high‑resolution BMP files to Photoshop PSD format in a C# application while keeping the resulting files as small as possible.
 * 2. When batch‑processing a large collection of bitmap assets for a design pipeline and want each PSD to use RLE compression to save disk space.
 * 3. When developing a .NET service that stores user‑uploaded images as PSDs and must limit storage costs by applying lossless compression.
 * 4. When preparing PSD files for version‑control systems where smaller file sizes reduce commit times and repository size.
 * 5. When generating PSD previews from BMP sources on a server with limited bandwidth and you want to minimize the amount of data transferred.
 */
