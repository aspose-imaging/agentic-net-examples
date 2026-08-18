// HOW-TO: Convert Odd Pages of DjVu to Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample_odd_pages.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Convert to 1‑bit B/W (optional, based on example)
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Determine the range of odd‑numbered pages (0‑based index)
                int lastPageIndex = djvuImage.PageCount - 1;
                // IntRange(start, end, step) – selects pages 0,2,4,... which are odd‑numbered in 1‑based terms
                IntRange oddPagesRange = new IntRange(0, lastPageIndex, 2);

                // Apply the range via DjvuMultiPageOptions
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPagesRange);

                // Save selected pages to a multi‑page TIFF file
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
 * 1. When you need to extract only the odd‑numbered pages from a scanned DjVu archive and save them as a compressed multi‑page TIFF for archival or printing.
 * 2. When a document workflow requires converting selected pages of a DjVu file to 1‑bit black‑and‑white TIFF to reduce file size while preserving readability.
 * 3. When integrating Aspose.Imaging into a C# application that processes large DjVu collections and must generate separate TIFF files for every other page for batch OCR.
 * 4. When automating the creation of thumbnail previews by converting the first, third, and fifth pages of a DjVu document into a single TIFF sprite sheet.
 * 5. When a legal or medical imaging system needs to export only the odd pages of a DjVu report into a deflate‑compressed TIFF for secure electronic submission.
 */
