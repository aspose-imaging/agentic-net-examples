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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output_compressed.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the existing TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for JPEG compression with 80% quality
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Jpeg,
                    CompressedQuality = 80,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Save the image with the specified options
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
 * 1. When a medical imaging application must reduce the storage size of high‑resolution DICOM‑converted TIFF scans for faster archival while preserving acceptable visual quality, a developer can use this code to apply JPEG compression at 80 % quality.
 * 2. When a document management system needs to upload multi‑page TIFF invoices to a cloud service that enforces file‑size limits, the code can compress each TIFF page using JPEG compression to meet the quota.
 * 3. When a GIS workflow generates large satellite imagery TIFF files and wants to speed up network transfer to remote servers, a developer can apply the 80 % JPEG quality setting to shrink the files without losing critical color information.
 * 4. When an e‑commerce platform stores product catalog images as TIFF for print‑ready output but wants to create smaller preview files for web thumbnails, this C# snippet can compress the TIFFs while keeping RGB color fidelity.
 * 5. When a digital archiving script processes scanned historical documents in TIFF format and must balance preservation quality with limited disk space, the developer can use the example to compress the images with JPEG at an 80 % quality factor.
 */