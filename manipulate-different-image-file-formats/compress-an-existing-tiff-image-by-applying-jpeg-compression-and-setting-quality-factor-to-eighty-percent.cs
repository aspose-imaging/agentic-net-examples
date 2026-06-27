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
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output_compressed.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for JPEG compression with 80% quality
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Jpeg;
                tiffOptions.CompressedQuality = 80;
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                // Save the compressed image
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
 * 1. When a developer needs to reduce the file size of high‑resolution TIFF scans for faster web delivery by applying JPEG compression with an 80 % quality setting.
 * 2. When integrating a document management system that stores scanned PDFs as TIFFs and wants to save storage space by recompressing each image using C# and Aspose.Imaging.
 * 3. When building a batch‑processing tool that converts legacy multi‑page TIFF archives into smaller, JPEG‑compressed TIFF files for archival while preserving RGB color.
 * 4. When creating a medical imaging workflow that must compress DICOM‑derived TIFF images before transmitting them over a network, using .NET to set compression and quality parameters.
 * 5. When developing a desktop application that allows users to upload large TIFF photos and automatically compresses them to meet email attachment size limits using Aspose.Imaging’s TiffOptions.
 */