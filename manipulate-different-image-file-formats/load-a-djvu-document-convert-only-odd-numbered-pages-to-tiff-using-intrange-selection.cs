using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\odd_pages.tif";

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

            // Load DjVu document from stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Determine odd‑numbered pages (1‑based odd => 0‑based even indices)
                int pageCount = djvuImage.PageCount;
                List<int> oddPageIndices = new List<int>();
                for (int i = 0; i < pageCount; i++)
                {
                    if (i % 2 == 0) // zero‑based even index corresponds to odd page number
                    {
                        oddPageIndices.Add(i);
                    }
                }

                // Set pages to export using DjvuMultiPageOptions
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPageIndices.ToArray());

                // Save selected pages to TIFF
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
 * 1. When a developer needs to extract only the odd‑numbered pages from a multi‑page DjVu archive and save them as a compressed TIFF for archival or printing.
 * 2. When an application must generate a lightweight TIFF preview of every other page in a scanned DjVu document to reduce file size while preserving readability.
 * 3. When a workflow requires converting selected DjVu pages (e.g., page 1, 3, 5…) to a 1‑bit‑per‑pixel TIFF using Deflate compression for OCR preprocessing.
 * 4. When a .NET service processes incoming DjVu files and needs to output only the odd pages as a multi‑page TIFF to comply with a legacy system that only accepts TIFF input.
 * 5. When a batch job automates the extraction of odd pages from DjVu manuals and stores them in a TIFF format for inclusion in a digital library that indexes TIFF images.
 */