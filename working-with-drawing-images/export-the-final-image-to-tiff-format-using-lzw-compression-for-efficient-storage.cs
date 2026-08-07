using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.jpg";
            string outputPath = @"C:\temp\output_lzw.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // 8 bits per color component (RGB)
                BitsPerSample = new ushort[] { 8, 8, 8 },

                // Use Big Endian byte order (Motorola)
                ByteOrder = TiffByteOrder.BigEndian,

                // LZW compression
                Compression = TiffCompressions.Lzw,

                // Predictor improves LZW compression for continuous-tone images
                Predictor = TiffPredictor.Horizontal,

                // RGB photometric interpretation
                Photometric = TiffPhotometrics.Rgb,

                // Store all components in a single plane
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            // Load the source image and save it as TIFF with the configured options
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to archive high‑resolution photographs in a lossless but space‑efficient format, they can use this C# code with Aspose.Imaging to convert JPEGs to LZW‑compressed TIFF files.
 * 2. When a medical‑imaging application must store scans as TIFF with predictable byte order and RGB photometric interpretation, the sample demonstrates how to enforce Big‑Endian and appropriate TIFF settings.
 * 3. When a GIS system requires raster layers to be saved as contiguous‑planar TIFFs with LZW compression for faster network loading, this snippet shows the exact configuration.
 * 4. When a print‑shop workflow needs to generate print‑ready TIFF files with 8‑bit per channel color and a horizontal predictor to reduce file size without sacrificing quality, the code provides the necessary steps.
 * 5. When a document‑management platform must batch‑convert user‑uploaded JPEGs to archival‑grade TIFFs using C# and Aspose.Imaging while ensuring the output directory exists, this example illustrates the complete process.
 */