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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.tif";

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
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Optional: force B/W output
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Select pages 5‑7 (zero‑based indexes 4,5,6)
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 });
                tiffOptions.MultiPageOptions = multiPageOptions;

                // Save selected pages as a multipage TIFF
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
 * 1. When a developer needs to extract specific pages (e.g., pages 5‑7) from a DjVu document and archive them as a compressed, black‑and‑white multipage TIFF for long‑term storage or printing.
 * 2. When an application must convert selected DjVu pages into a single TIFF file to feed a downstream OCR engine that only accepts TIFF input.
 * 3. When a digital library system wants to provide users with downloadable excerpts of scanned books by converting chosen DjVu pages into a deflate‑compressed TIFF bundle.
 * 4. When a workflow automates the creation of multi‑page TIFF reports from multi‑page DjVu source files, preserving page order and applying B/W bit depth for reduced file size.
 * 5. When a C# service processes incoming DjVu submissions and needs to generate a single multipage TIFF containing only the relevant pages for compliance auditing or legal review.
 */