using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

namespace DjvuToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directory
                string inputPath = @"c:\temp\sample.djvu";
                string outputDir = @"c:\temp\";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu image from stream
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Log total number of pages
                        Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                        // Iterate through each page and save as PNG
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET application must extract each page of a multi‑page DjVu document and generate PNG thumbnails for preview in a web gallery.
 * 2. When a document‑management system needs to verify the number of pages in a DjVu file before archiving and store each page as a lossless PNG for downstream processing.
 * 3. When a batch‑conversion utility is required to read DjVu scans from a folder, log the page count for audit purposes, and output individual PNG images for OCR engines.
 * 4. When an e‑learning platform wants to display DjVu lecture notes on mobile devices by converting every page to PNG at runtime using C# and Aspose.Imaging.
 * 5. When a legacy workflow needs to programmatically open a DjVu stream, ensure the file exists, and save each page as a PNG file for integration with a PDF generation pipeline.
 */