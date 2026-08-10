// HOW-TO: Convert CMX to 8‑Bit TIFF with LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.cmx";
        string outputPath = @"c:\temp\output.tif";

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

            // Configure TIFF save options for 8 bits per color component
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },                     // 8 bits per channel
                ByteOrder = TiffByteOrder.BigEndian,                         // Motorola byte order
                Compression = TiffCompressions.Lzw,                         // LZW compression
                Photometric = TiffPhotometrics.Rgb,                         // RGB photometric
                PlanarConfiguration = TiffPlanarConfigs.Contiguous          // Single plane
            };

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Save as TIFF using the configured options
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive legacy CorelDRAW CMX artwork as lossless 8‑bit per channel TIFF files for long‑term storage.
 * 2. When a printing workflow requires converting CMX designs to TIFF with exact 8‑bit RGB color depth and LZW compression before sending to a RIP.
 * 3. When a web service must transform uploaded CMX files into standard TIFF images that can be displayed in browsers or processed by other libraries.
 * 4. When migrating a batch of CMX assets to a TIFF‑based digital asset management system and you need to ensure consistent byte order and planar configuration.
 * 5. When integrating Aspose.Imaging into a C# application to programmatically convert CMX drawings to TIFF while controlling bits per sample and compression settings.
 */
