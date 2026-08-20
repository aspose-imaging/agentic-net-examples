// HOW-TO: Convert EPS to PSD With RLE Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.eps";
        string outputPath = @"C:\temp\sample_converted.psd";

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

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Use RLE compression to reduce file size while preserving quality
                    CompressionMethod = CompressionMethod.RLE,
                    // Typical settings for color depth and channels
                    ChannelBitsCount = 8,
                    ChannelsCount = 4,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    // Keep default PSD version (6)
                    Version = 6
                };

                // Save as PSD with the specified options
                epsImage.Save(outputPath, psdOptions);
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
 * 1. When a designer needs to export vector EPS artwork to a layered PSD file while keeping file size low, this code converts the EPS and applies RLE compression.
 * 2. When an automated build pipeline processes print‑ready EPS files and must generate PSDs compatible with Photoshop without losing color fidelity, the example shows how to set the appropriate color mode and channel depth.
 * 3. When a web service receives EPS uploads and must store them as PSDs with balanced quality and storage costs, the RLE compression option reduces the resulting file size.
 * 4. When migrating legacy EPS assets to a Photoshop workflow, developers can use this code to preserve the RGB color space and PSD version while applying efficient compression.
 * 5. When creating a batch conversion tool that converts multiple EPS files to PSDs in C#, the snippet demonstrates how to configure Aspose.Imaging options for consistent compression across all images.
 */
