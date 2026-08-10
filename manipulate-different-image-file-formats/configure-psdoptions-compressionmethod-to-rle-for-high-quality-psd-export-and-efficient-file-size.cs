// HOW-TO: How To Export BMP To PSD With RLE Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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
                // Configure PSD save options with RLE compression
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
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a bitmap image to a Photoshop PSD file while keeping lossless quality and reducing file size using RLE compression.
 * 2. When automating a batch process that generates PSD files from source images for a design workflow and you want efficient storage.
 * 3. When integrating Aspose.Imaging into a C# application that must produce PSDs compatible with Photoshop’s RLE compression for archival purposes.
 * 4. When building a server‑side service that receives BMP uploads and returns compressed PSDs to clients to save bandwidth.
 * 5. When creating a desktop utility that prepares high‑resolution assets for Photoshop editors, ensuring the PSDs use RLE to balance quality and size.
 */
