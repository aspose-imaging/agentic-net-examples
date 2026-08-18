// HOW-TO: Convert Specific DjVu Pages to Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options for multi-page output
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;

                // Specify pages 5‑7 (zero‑based indexes 4,5,6)
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 });

                // Save selected pages as a single multi‑page TIFF file
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract a range of pages from a DjVu document and archive them as a single TIFF file for printing or review.
 * 2. When a legal or archival system requires selected DjVu pages to be stored in a lossless, multi‑page TIFF format for compliance.
 * 3. When an application must programmatically convert scanned book sections (pages 5‑7) from DjVu to TIFF to integrate with existing TIFF‑based workflows.
 * 4. When you want to reduce file size by using Deflate compression while preserving multiple pages in one TIFF image.
 * 5. When automating batch processing of DjVu files to create multi‑page TIFFs for downstream image analysis or OCR pipelines.
 */
