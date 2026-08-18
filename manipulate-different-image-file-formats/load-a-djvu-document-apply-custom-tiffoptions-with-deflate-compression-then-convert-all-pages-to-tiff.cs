// HOW-TO: Convert DjVu Document To Multi‑Page Deflate TIFF In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/sample.djvu";
            string outputPath = "output/sample.tif";

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

                // Enable multi‑page export (all pages by default)
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages as a multi‑page TIFF file
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
 * 1. When you need to archive scanned DjVu files as compressed multi‑page TIFFs for long‑term storage.
 * 2. When a workflow requires converting each page of a DjVu ebook into a single TIFF file with Deflate compression to reduce file size.
 * 3. When integrating Aspose.Imaging into a .NET application that must batch‑process DjVu documents and output them as TIFFs compatible with legacy imaging systems.
 * 4. When you want to ensure all pages of a DjVu file are preserved in a single TIFF while using lossless Deflate compression for efficient transmission.
 * 5. When automating document conversion on a server and you need to verify the input DjVu exists and create the output directory before saving the TIFF.
 */
