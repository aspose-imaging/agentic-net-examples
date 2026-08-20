// HOW-TO: Convert BMP to PSD with ZIP Compression and RGB Mode in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\output.psd";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options: ZIP (RLE) compression and RGB color mode
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE, // ZIP-like compression for PSD
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as PSD with the specified options
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
 * 1. When you need to import legacy BMP assets into a Photoshop workflow while keeping file size low by using RLE compression.
 * 2. When an automated .NET service must batch‑convert scanned BMP images to PSD files with RGB color mode for further editing.
 * 3. When a graphics pipeline requires preserving pixel data from BMP files in a layered PSD format without losing color fidelity.
 * 4. When you want to generate PSD files from BMP sources on a server, ensuring the output uses ZIP‑style (RLE) compression for faster download.
 * 5. When integrating Aspose.Imaging into a C# application to transform BMP screenshots into PSD files ready for Photoshop designers.
 */
