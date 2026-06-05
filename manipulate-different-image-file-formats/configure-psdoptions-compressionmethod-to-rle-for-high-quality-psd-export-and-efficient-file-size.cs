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
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application needs to convert high‑resolution BMP files to Photoshop PSD files while preserving image quality and minimizing file size for archival in a digital asset management system.
 * 2. When an automated build pipeline generates design mockups and must export them as PSDs with RLE compression so that downstream Photoshop scripts can edit them without excessive storage overhead.
 * 3. When a web service receives user‑uploaded bitmap images and must provide downloadable PSD versions that retain layer fidelity yet stay within bandwidth limits for email delivery.
 * 4. When a desktop utility batch‑processes a folder of scanned documents, converting each to PSD using RLE compression to ensure lossless compression for professional printing workflows.
 * 5. When integrating Aspose.Imaging into a C# plugin for a graphics editor that needs to save edited images as PSDs with efficient RLE compression to speed up save operations on low‑memory devices.
 */