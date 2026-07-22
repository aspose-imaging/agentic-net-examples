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
        string outputPath = @"C:\Temp\sample.tif";

        // Ensure any runtime exception is reported without crashing
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

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options with Deflate compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Deflate;

                // Save all pages of the DjVu document as a multi-page TIFF
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
 * 1. When a legal firm needs to archive scanned case files stored as DjVu into a single multi‑page TIFF with lossless Deflate compression for long‑term storage.
 * 2. When a publishing company wants to convert a multi‑page DjVu manuscript into a TIFF package that can be imported into desktop publishing software that only supports TIFF.
 * 3. When a government agency must batch‑process DjVu documents received from the public and save them as compressed TIFFs to reduce disk usage while preserving image quality.
 * 4. When a medical imaging system receives diagnostic reports in DjVu format and needs to transform them into multi‑page TIFFs for compatibility with PACS viewers that require TIFF input.
 * 5. When a cloud‑based document management service provides an API that reads DjVu streams in C# and returns a single TIFF file using Deflate compression to optimize bandwidth for client downloads.
 */