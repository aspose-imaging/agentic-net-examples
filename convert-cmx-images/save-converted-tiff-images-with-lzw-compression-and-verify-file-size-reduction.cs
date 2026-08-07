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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_lzw.tif";

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
                // Configure TIFF save options with LZW compression
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    // Optional predictor to improve compression for continuous-tone images
                    Predictor = TiffPredictor.Horizontal,
                    // Preserve original color model
                    Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                    // Store color components in a single plane
                    PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous,
                    // 8 bits per sample for each color component
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Save the image as TIFF with LZW compression
                image.Save(outputPath, tiffOptions);
            }

            // Compare file sizes to verify reduction
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");

            if (compressedSize < originalSize)
            {
                Console.WriteLine("File size reduction achieved.");
            }
            else
            {
                Console.WriteLine("No size reduction detected.");
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
 * 1. When a developer needs to archive high‑resolution photographs as TIFF files with lossless LZW compression to reduce storage space while preserving image quality.
 * 2. When a medical imaging application must convert JPEG scans to TIFF with LZW compression to meet DICOM compliance and verify that the file size is smaller than the original.
 * 3. When a document management system requires batch conversion of user‑uploaded JPEGs to TIFF with LZW compression and needs to log the size savings for reporting.
 * 4. When a GIS tool converts satellite imagery from JPEG to TIFF using LZW compression to ensure efficient disk usage and checks the reduction before publishing.
 * 5. When a print‑ready workflow transforms source images to TIFF with LZW compression to maintain color fidelity and confirms the compressed file fits within printer memory limits.
 */