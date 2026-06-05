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
            string inputPath = @"C:\Temp\sample.djvu";
            string outputDirectory = @"C:\Temp\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through all pages
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        int pageNumber = page.PageNumber;

                        // Process only pages 10 to 15 inclusive
                        if (pageNumber < 10 || pageNumber > 15)
                            continue;

                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
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
 * 1. When a legal firm needs to extract pages 10‑15 from a multi‑page DjVu contract and save them as PNG files for inclusion in an e‑discovery portal.
 * 2. When a publishing company wants to generate preview PNG images of specific chapters (pages 10‑15) from a DjVu manuscript to display on a web catalog.
 * 3. When a document management system must convert selected DjVu pages to PNG thumbnails for faster indexing and search‑result previews.
 * 4. When a scientific research team extracts high‑resolution PNG images of pages 10‑15 from a scanned DjVu journal to annotate figures in a paper.
 * 5. When archival software automates the batch conversion of a DjVu archive’s middle pages (10‑15) into PNG files for compatibility with legacy image viewers.
 */