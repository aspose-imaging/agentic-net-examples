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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.djvu";
            string outputPath = @"c:\temp\sample.tif";

            // Verify input file exists
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
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Deflate;

                // Set MultiPageOptions to include all pages
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages to a single multi-page TIFF file
                djvuImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to archive scanned legal documents originally stored as DjVu files into a single multi‑page TIFF with lossless Deflate compression for easy viewing in standard office applications.
 * 2. When a .NET application must batch‑convert historic DjVu archives of engineering drawings into TIFF format while preserving all pages in one file for integration with document management systems.
 * 3. When a software solution requires extracting every page from a DjVu e‑book and saving it as a compressed TIFF to reduce storage size without sacrificing image quality.
 * 4. When an image‑processing pipeline needs to read a DjVu image stream, apply custom TiffOptions, and output a multi‑page TIFF that can be processed further by OCR engines.
 * 5. When a developer wants to ensure that a DjVu file is programmatically validated, converted, and saved as a Deflate‑compressed TIFF to meet regulatory compliance for archival records.
 */