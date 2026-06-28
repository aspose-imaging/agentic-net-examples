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
        string inputPath = @"c:\temp\sample.djvu";
        string outputDirectory = @"c:\temp\";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Log total number of pages
                    Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                    // Iterate through each page and save as PNG
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"sample.{djvuPage.PageNumber}.png");

                        // Ensure output directory exists
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as individual PNG images for web preview or thumbnail generation.
 * 2. When an application must programmatically determine the total number of pages in a DjVu file before processing or displaying pagination controls in a C# UI.
 * 3. When a document management system requires converting scanned DjVu archives into lossless PNG files to preserve image quality while enabling downstream OCR processing.
 * 4. When a batch‑processing script has to validate the existence of a DjVu source file, log its page count, and reliably write the converted PNG pages to a specified output folder using Aspose.Imaging for .NET.
 * 5. When a developer wants to integrate DjVu to PNG conversion into a .NET service that reads the DjVu stream, iterates over DjvuPage objects, and saves each page with a naming convention that includes the page number.
 */