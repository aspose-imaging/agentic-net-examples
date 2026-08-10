// HOW-TO: Convert First Three DjVu Pages to PNG and Merge into TIFF in C# (Aspose.Imaging for .NET)
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
            string[] pngOutputPaths = new string[]
            {
                @"C:\temp\page1.png",
                @"C:\temp\page2.png",
                @"C:\temp\page3.png"
            };
            string tiffOutputPath = @"C:\temp\merged.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            foreach (var pngPath in pngOutputPaths)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert first three pages to PNG
                for (int i = 0; i < 3 && i < djvuImage.Pages.Length; i++)
                {
                    var djvuPage = (DjvuPage)djvuImage.Pages[i];
                    djvuPage.Save(pngOutputPaths[i], new PngOptions());
                }

                // Prepare TIFF save options for multi‑page output
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
                tiffOptions.MultiPageOptions.Pages = new int[] { 0, 1, 2 }; // export pages 1‑3 (zero‑based)

                // Save merged multi‑page TIFF
                djvuImage.Save(tiffOutputPath, tiffOptions);
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
 * 1. When you need to extract individual pages from a DjVu document as high‑quality PNG images for web preview or further editing.
 * 2. When you must create a single multi‑page TIFF file from selected DjVu pages to archive or print them as a continuous document.
 * 3. When a workflow requires converting scanned DjVu files into PNG for OCR processing while preserving the original page order.
 * 4. When integrating legacy DjVu archives into a .NET application that outputs TIFF bundles for compatibility with document management systems.
 * 5. When automating batch conversion of specific DjVu pages to PNG and then combining them into a compressed TIFF for efficient storage or transmission.
 */
