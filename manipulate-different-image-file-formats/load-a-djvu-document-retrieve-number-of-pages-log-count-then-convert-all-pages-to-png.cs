using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for PNG files
            string outputDir = @"C:\Temp\Output";

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Log the total number of pages
                    Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                    // Iterate through each page and save as PNG
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build the output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG using Aspose.Imaging PNG options
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract every page from a multi‑page DjVu document (such as scanned books) and generate PNG images for web preview.
 * 2. When an application must read a DjVu file, log its total page count, and display pagination information to users.
 * 3. When a batch conversion utility converts archival DjVu files to PNG format to ensure compatibility with image editors that do not support DjVu.
 * 4. When a document management system records the page count of uploaded DjVu files and saves each page as a separate PNG thumbnail for quick search indexing.
 * 5. When a C# service processes DjVu files from a shared folder, creates PNG versions of each page, and writes them to a designated output directory for downstream processing.
 */