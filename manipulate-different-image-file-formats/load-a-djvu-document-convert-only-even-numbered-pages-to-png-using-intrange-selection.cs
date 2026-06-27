using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputDirectory = @"C:\Temp\Output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through all pages
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Process only even-numbered pages
                    if (djvuPage.PageNumber % 2 == 0)
                    {
                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                        // Ensure the directory for the output file exists
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
 * 1. When a document management system needs to extract and display only the even‑numbered pages of a multi‑page DjVu file as PNG thumbnails for a web preview.
 * 2. When an e‑learning platform wants to generate PNG images of every second page of scanned lecture notes stored in DjVu format to reduce storage while still providing sample pages.
 * 3. When a legal firm automates the creation of PNG copies of even pages from large DjVu case files to embed them into PDF reports using C# and Aspose.Imaging.
 * 4. When a digital archiving tool processes DjVu archives and selectively converts even pages to PNG for OCR preprocessing without converting the entire document.
 * 5. When a batch‑processing script must read DjVu files from a folder and output PNG images of only the even‑numbered pages to a separate directory for downstream image analysis.
 */