// HOW-TO: Extract DjVu Pages 10 to 15 As PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG files
            string outputDir = "Output";

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through pages and export pages 10 to 15 as PNG
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    int pageNumber = page.PageNumber;
                    if (pageNumber >= 10 && pageNumber <= 15)
                    {
                        // Construct output file path
                        string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.png");

                        // Ensure output directory exists
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
 * 1. When you need to generate preview thumbnails for specific pages of a multi‑page DjVu document in a web application.
 * 2. When you want to archive only a subset of pages from a large DjVu file as high‑quality PNG files for printing or review.
 * 3. When a document processing pipeline must convert selected DjVu pages to PNG to feed into OCR or image analysis tools.
 * 4. When a desktop utility must extract pages 10‑15 from scanned manuals stored as DjVu and save them as separate PNG images for distribution.
 * 5. When automating batch conversion of particular DjVu pages to PNG for inclusion in a PowerPoint presentation or report.
 */
