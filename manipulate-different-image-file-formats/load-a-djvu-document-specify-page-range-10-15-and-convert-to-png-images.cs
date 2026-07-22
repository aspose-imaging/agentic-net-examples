using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file and output directory
        string inputPath = @"C:\temp\sample.djvu";
        string outputDir = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream and load it
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through all pages
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    int pageNumber = djvuPage.PageNumber;

                    // Process only pages 10 through 15
                    if (pageNumber < 10 || pageNumber > 15)
                        continue;

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract and convert specific pages (10‑15) from a multi‑page DjVu document into high‑quality PNG images for web preview or thumbnail generation.
 * 2. When an application must programmatically batch‑process scanned books stored as DjVu files, converting only a subset of pages to PNG for inclusion in an e‑learning platform.
 * 3. When a digital archiving system requires converting selected DjVu pages to PNG to preserve visual fidelity while enabling compatibility with standard image viewers.
 * 4. When a document management workflow automates the creation of printable PNG assets from particular DjVu pages for legal or publishing purposes.
 * 5. When a C# service needs to validate the existence of a DjVu file, load it via Aspose.Imaging, and save pages 10‑15 as PNG files for downstream image analysis or OCR processing.
 */