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
            string inputPath = @"C:\temp\sample.djvu";
            string outputPath = @"C:\temp\sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options with Deflate compression
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    saveOptions.Compression = TiffCompressions.Deflate;

                    // Optional: set MultiPageOptions to include all pages (default behavior)
                    saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

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
 * 1. When a developer needs to archive scanned DjVu documents as a single multi‑page TIFF file using lossless Deflate compression for long‑term storage.
 * 2. When a .NET application must batch‑convert DjVu e‑books into TIFF format so legacy printing systems that only accept TIFF can process them.
 * 3. When an image‑processing pipeline requires loading DjVu pages from a stream and saving them as a high‑quality TIFF with custom TiffOptions.
 * 4. When a document‑management system integrates DjVu to TIFF conversion, using Aspose.Imaging to apply Deflate compression and reduce file size while preserving fidelity.
 * 5. When a C# service reads DjVu files from a network location and generates a multi‑page TIFF for downstream OCR or archival workflows.
 */