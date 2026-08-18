// HOW-TO: Convert DjVu Pages 2 to 5 into a Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
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

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Deflate;
                // Convert to black/white (1 bit per sample)
                saveOptions.BitsPerSample = new ushort[] { 1 };

                // Specify page range 2‑5 (zero‑based indexes 1‑4)
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 1, 2, 3, 4 });

                // Optional: set page titles
                saveOptions.MultiPageOptions.PageTitles = new string[]
                {
                    "Page 2",
                    "Page 3",
                    "Page 4",
                    "Page 5"
                };

                // Save as multipage TIFF
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
 * 1. When you need to extract a subset of pages from a DjVu document and archive them as a single compressed black‑and‑white multi‑page TIFF for easy viewing in Windows.
 * 2. When a legal or medical workflow requires converting specific DjVu pages (e.g., pages 2‑5) into a searchable TIFF file to attach to an electronic case file.
 * 3. When you want to reduce file size by saving selected DjVu pages as a Deflate‑compressed 1‑bit TIFF for printing or long‑term storage.
 * 4. When an application must programmatically generate a multi‑page TIFF from a DjVu source, preserving page titles for later reference in a document management system.
 * 5. When you need to automate the conversion of a DjVu e‑book’s middle chapters into a TIFF format that can be processed by legacy imaging tools that only support TIFF.
 */
