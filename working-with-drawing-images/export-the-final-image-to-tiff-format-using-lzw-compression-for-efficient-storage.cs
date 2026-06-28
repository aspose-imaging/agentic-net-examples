using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.tif";

            // Validate input file existence
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
                // Configure TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;

                // Save the image as TIFF using the configured options
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
 * 1. When a developer needs to convert high‑resolution JPEG photographs to lossless TIFF files with LZW compression for archival storage while preserving image quality.
 * 2. When an application must generate TIFF documents for a medical imaging system that requires the LZW algorithm to meet DICOM file size constraints.
 * 3. When a batch‑processing tool has to export scanned receipts from JPEG to TIFF to enable OCR engines that only accept TIFF with LZW compression.
 * 4. When a GIS workflow requires converting satellite imagery from JPEG to TIFF with LZW to reduce disk usage without losing raster data.
 * 5. When a document management solution needs to store user‑uploaded images as TIFF files with LZW compression to ensure consistent format and efficient retrieval.
 */