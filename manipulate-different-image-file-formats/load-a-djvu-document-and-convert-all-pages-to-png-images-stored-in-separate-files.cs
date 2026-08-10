// HOW-TO: Convert Multi‑Page DjVu Document to Separate PNG Files in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\temp\sample.djvu";
        string outputDir = @"C:\temp\";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file name based on page number
                        string fileName = $"sample.{djvuPage.PageNumber}.png";
                        string outputPath = Path.Combine(outputDir, fileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
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
 * 1. When you need to extract each page of a scanned DjVu book and save them as individual PNG images for web preview.
 * 2. When an application must batch‑convert DjVu reports into high‑resolution PNG files for inclusion in a PDF generation workflow.
 * 3. When you want to archive multi‑page DjVu technical manuals as separate PNG assets to simplify version control.
 * 4. When a document‑processing service requires converting DjVu pages to PNG to apply further image analysis or OCR.
 * 5. When a mobile app needs to display DjVu content by first converting each page to PNG thumbnails on the server.
 */
