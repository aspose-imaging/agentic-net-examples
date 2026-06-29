using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
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
                DngImage dngImage = (DngImage)image;

                // Configure TIFF options for 16‑bit per channel
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 },               // 16 bits for R, G, B
                    Photometric = TiffPhotometrics.Rgb,                       // RGB color model
                    Compression = TiffCompressions.None,                     // No compression
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous,      // Single plane
                    ByteOrder = TiffByteOrder.LittleEndian                    // Default byte order
                };

                // Save as 16‑bit TIFF
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
 * 1. When a photographer needs to archive raw DNG files as lossless 16‑bit TIFFs for long‑term storage while preserving the original sensor data for future editing.
 * 2. When a scientific imaging application requires importing camera raw DNG images and converting them to 16‑bit TIFF to maintain high dynamic range for analysis pipelines written in C#.
 * 3. When a printing workflow must transform raw DNG files into uncompressed 16‑bit TIFFs to ensure color fidelity and bit‑depth compatibility with RIP software.
 * 4. When a digital asset management system needs to generate preview‑ready 16‑bit TIFF copies of DNG files using Aspose.Imaging for .NET to support accurate thumbnail rendering.
 * 5. When a machine‑learning model for image classification is trained on raw sensor data, developers can use this code to convert DNG inputs to 16‑bit TIFFs that retain the full bit depth for training consistency.
 */