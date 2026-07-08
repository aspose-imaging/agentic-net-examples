using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Retrieve and log the total number of pages
                int pageCount = djvuImage.PageCount;
                Console.WriteLine($"Total pages: {pageCount}");

                // Convert each page to PNG
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
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
 * 1. When a document management system needs to ingest multi‑page DjVu files, count the pages for metadata, and then convert each page to PNG for web preview.
 * 2. When a batch‑processing tool must verify the number of pages in scanned DjVu archives before exporting them as individual PNG images for OCR pipelines.
 * 3. When an e‑learning platform wants to display the total slide count of a DjVu lecture and generate PNG thumbnails for each slide using C# and Aspose.Imaging.
 * 4. When a digital archiving solution requires logging the page count of incoming DjVu submissions to track storage usage and then convert pages to PNG for compatibility with downstream image editors.
 * 5. When a desktop application needs to read a DjVu file from a stream, report its page count in the UI, and save each page as a high‑quality PNG for printing or further processing.
 */