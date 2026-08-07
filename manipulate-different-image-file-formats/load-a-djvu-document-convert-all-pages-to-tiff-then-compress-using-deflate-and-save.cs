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

        // Validate input file existence
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
 * 1. When a developer needs to archive scanned documents originally stored as DjVu files by converting every page into a single multi‑page TIFF with lossless Deflate compression for long‑term storage.
 * 2. When a .NET application must generate printable TIFF files from a DjVu e‑book so that downstream printing services that only accept TIFF can process the document.
 * 3. When a workflow requires extracting all pages of a DjVu technical manual and saving them as a compressed TIFF bundle to reduce file size before uploading to a document management system.
 * 4. When a developer wants to integrate Aspose.Imaging into a C# service that transforms DjVu legal filings into TIFF format with Deflate compression to meet court‑mandated file format standards.
 * 5. When an image processing pipeline needs to read a DjVu image stream, apply multi‑page export, and output a single TIFF file with Deflate compression for efficient network transmission.
 */