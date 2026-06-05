using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDir = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through all pages
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Process only even-numbered pages
                        if (djvuPage.PageNumber % 2 == 0)
                        {
                            // Build output file path
                            string outputPath = Path.Combine(outputDir, $"page_{djvuPage.PageNumber}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
                        }
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
 * 1. When a developer needs to extract only the even‑numbered pages from a multi‑page DjVu document and save them as high‑quality PNG images for web preview.
 * 2. When an archival system must convert selected pages of scanned DjVu files to PNG thumbnails while ignoring odd pages to reduce storage.
 * 3. When a batch‑processing tool automates the conversion of every second page of a DjVu e‑book into PNG for use in a mobile reading app.
 * 4. When a document‑management workflow extracts even pages from DjVu contracts to generate PNG assets for OCR processing.
 * 5. When a reporting service generates PNG screenshots of even‑numbered DjVu pages to embed in PDF summaries or email attachments.
 */