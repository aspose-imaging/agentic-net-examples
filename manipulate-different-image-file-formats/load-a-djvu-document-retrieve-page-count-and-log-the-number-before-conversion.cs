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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.djvu";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Retrieve and log page count before any conversion
                int pageCount = djvuImage.PageCount;
                Console.WriteLine($"Total number of pages: {pageCount}");

                // Convert each page to PNG
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"sample.{djvuPage.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
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
 * 1. When a document management system needs to validate the number of pages in a DjVu file before batch converting each page to PNG for web preview.
 * 2. When an archival workflow must log the page count of scanned books stored as DjVu to ensure completeness before extracting individual pages as images.
 * 3. When a digital publishing platform wants to display a progress indicator by reading the total page count of a DjVu manuscript prior to converting pages to PNG thumbnails.
 * 4. When a quality‑control script checks that a DjVu file contains the expected number of pages before generating PNG assets for downstream image processing.
 * 5. When a migration tool processes legacy DjVu files, it first reads and records the page count to maintain metadata while converting each page to PNG files.
 */