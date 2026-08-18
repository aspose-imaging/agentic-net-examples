// HOW-TO: Convert DNG Raw Image to 16‑Bit TIFF Without Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

                // Configure TIFF options for 16‑bit per channel output
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 },          // 16 bits for R, G, B
                    Compression = TiffCompressions.None,                // No compression to preserve raw data
                    Photometric = TiffPhotometrics.Rgb,                  // RGB color model
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous, // Single plane
                    ByteOrder = TiffByteOrder.LittleEndian               // Typical byte order
                };

                // Save as TIFF
                dngImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to export a camera’s raw DNG file to a 16‑bit TIFF for archival while keeping the original sensor data intact.
 * 2. When a photo‑editing pipeline requires uncompressed high‑depth TIFFs generated from DNG files for accurate color grading.
 * 3. When a scientific imaging application must convert raw sensor data to a standard TIFF format for analysis in other tools.
 * 4. When building a batch‑processing tool that transforms DNG files to loss‑less TIFFs to ensure compatibility with legacy software.
 * 5. When integrating Aspose.Imaging in a C# project to preserve raw image fidelity while converting between file formats.
 */
