using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file and output directory
        string inputPath = @"c:\temp\sample.djvu";
        string outputDir = @"c:\temp\output\";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PNG image
                        djvuPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as individual PNG files for web preview or thumbnail generation.
 * 2. When an application must batch‑process scanned archives stored in DjVu format and convert every page to high‑resolution PNG images for archival or OCR pipelines.
 * 3. When a C# service has to read a DjVu file from a stream, verify its existence, and output each page as a separate PNG to a configurable output folder.
 * 4. When integrating Aspose.Imaging into a document‑management system to automatically transform DjVu pages into PNGs for compatibility with browsers that do not support DjVu.
 * 5. When building a desktop utility that programmatically iterates through DjvuPage objects, creates missing directories, and saves each page as a PNG using PngOptions for further image processing.
 */