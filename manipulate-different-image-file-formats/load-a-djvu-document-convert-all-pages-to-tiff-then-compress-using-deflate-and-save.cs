using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (handles null or empty directory)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options with Deflate compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;

                    // Export all pages using DjvuMultiPageOptions
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    // Save the DjVu document as a multi-page TIFF
                    djvuImage.Save(outputPath, tiffOptions);
                }
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
 * 1. When a developer needs to archive scanned DjVu documents as a single multi‑page TIFF with lossless Deflate compression for long‑term storage.
 * 2. When an application must convert a DjVu e‑book into TIFF images to enable printing or OCR processing on Windows using C#.
 * 3. When a workflow requires batch conversion of all DjVu pages into one compressed TIFF file to reduce file count and simplify distribution to users with only TIFF viewers.
 * 4. When a developer wants to integrate DjVu‑to‑TIFF conversion into a .NET service that validates input files, creates missing output directories, and applies Deflate compression to minimize bandwidth.
 * 5. When a document management system needs to ingest DjVu files and store them as compressed multi‑page TIFFs to meet archival standards that mandate the TIFF format.
 */