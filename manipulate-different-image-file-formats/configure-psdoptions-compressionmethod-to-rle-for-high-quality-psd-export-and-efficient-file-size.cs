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
                // Configure PSD export options with RLE compression
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
                };

                // Save the image as PSD using the configured options
                image.Save(outputPath, psdOptions);
            }

            Console.WriteLine($"Image saved successfully to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution BMP assets to Photoshop PSD files while keeping lossless quality and reducing file size with RLE compression.
 * 2. When an automated build pipeline must generate PSD previews from source images for a design review system and wants efficient storage using Aspose.Imaging’s RLE compression.
 * 3. When a desktop application processes user‑uploaded bitmap graphics and saves them as layered PSD files for further editing in Photoshop, using RLE to balance quality and disk usage.
 * 4. When a server‑side service exports scanned documents as PSD files for archival, requiring lossless compression (RLE) to preserve detail without inflating storage costs.
 * 5. When a batch‑processing script needs to convert a folder of BMP files to PSD format in C# and ensure the output files are optimized for size while retaining full image fidelity via the CompressionMethod.RLE setting.
 */