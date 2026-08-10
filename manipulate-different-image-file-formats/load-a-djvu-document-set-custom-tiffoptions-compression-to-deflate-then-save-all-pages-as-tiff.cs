// HOW-TO: Convert DjVu To Multi‑Page TIFF With Deflate Compression In C# (Aspose.Imaging for .NET)
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

        try
        {
            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options with Deflate compression
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    saveOptions.Compression = TiffCompressions.Deflate;

                    // Save all pages as a multi‑page TIFF file
                    djvuImage.Save(outputPath, saveOptions);
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
 * 1. When you need to archive scanned documents originally in DjVu format as lossless, searchable multi‑page TIFF files for long‑term storage.
 * 2. When a printing workflow requires converting DjVu pages to TIFF with Deflate compression to reduce file size while preserving image quality.
 * 3. When integrating Aspose.Imaging into a C# application that batch‑processes DjVu files and outputs them as single TIFF files for compatibility with legacy systems.
 * 4. When you must generate TIFF images for OCR engines that only accept TIFF input, converting each DjVu page into a compressed TIFF container.
 * 5. When a document management system stores documents as DjVu but needs to provide users downloadable TIFF versions with efficient Deflate compression.
 */
