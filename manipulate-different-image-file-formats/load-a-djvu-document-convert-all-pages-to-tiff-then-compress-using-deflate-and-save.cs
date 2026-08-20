// HOW-TO: Convert DjVu Document to Multi‑Page Deflate Compressed TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output\\output.tif";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options with Deflate compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;

                // Export all pages
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save as TIFF
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
 * 1. When you need to archive scanned DjVu files as lossless TIFFs for long‑term storage while reducing file size with Deflate compression.
 * 2. When a document management system requires all pages of a DjVu document to be converted to a single multi‑page TIFF for compatibility with legacy printers.
 * 3. When you are building a batch conversion tool that extracts every page from DjVu ebooks and saves them as compressed TIFF images for downstream OCR processing.
 * 4. When integrating Aspose.Imaging into a C# application to transform DjVu blueprints into TIFF format that can be opened by standard image viewers without losing detail.
 * 5. When you must programmatically convert DjVu reports into TIFF files with Deflate compression to meet email attachment size limits.
 */
