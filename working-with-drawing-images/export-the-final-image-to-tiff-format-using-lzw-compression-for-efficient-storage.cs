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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output.tif";

            // Verify input file exists
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
                // Configure TIFF options for LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // 8 bits per color component
                    BitsPerSample = new ushort[] { 8, 8, 8 },

                    // Use Big Endian byte order (Motorola)
                    ByteOrder = TiffByteOrder.BigEndian,

                    // LZW compression
                    Compression = TiffCompressions.Lzw,

                    // Horizontal predictor improves LZW efficiency
                    Predictor = TiffPredictor.Horizontal,

                    // RGB photometric interpretation
                    Photometric = TiffPhotometrics.Rgb,

                    // Store all components in a single plane
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the image as a TIFF file with the specified options
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
 * 1. When a developer needs to convert high‑resolution JPEG photographs to lossless TIFF files with LZW compression for archival storage while preserving color depth and metadata.
 * 2. When a medical imaging application must export scanned X‑ray images to a TIFF format that uses Big‑Endian byte order and horizontal predictor to reduce file size without sacrificing diagnostic quality.
 * 3. When a GIS system requires batch processing of satellite imagery, converting each JPEG tile to a contiguous‑planar RGB TIFF with LZW compression for efficient transmission to remote servers.
 * 4. When an e‑commerce platform wants to generate print‑ready product images in TIFF with 8‑bit per channel color and LZW compression to meet printer specifications while keeping bandwidth usage low.
 * 5. When a document management workflow needs to store scanned documents as TIFF files with LZW compression and standardized photometric settings to ensure compatibility with legacy archival software.
 */