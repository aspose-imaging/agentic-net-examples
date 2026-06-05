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
            string inputPath = "input.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through all pages in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output BMP file path for the current page
                    string outputPath = Path.Combine("output", $"page_{page.PageNumber}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set BMP save options with 24 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    // Save the page as a BMP image using the specified options
                    page.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and store them as high‑color 24‑bit BMP files for legacy Windows applications.
 * 2. When a document management system must convert scanned DjVu archives into BMP images to generate thumbnails that preserve full color depth.
 * 3. When an archival workflow requires batch processing of DjVu files into BMP format with a fixed BitsPerPixel setting to ensure consistent image quality across all pages.
 * 4. When a C# service reads DjVu files from a file stream, iterates through pages, and saves them as BMP files for downstream OCR engines that only accept BMP input.
 * 5. When a developer integrates Aspose.Imaging into a .NET application to programmatically convert DjVu pages to BMP while controlling the pixel depth to 24 bits for accurate color reproduction.
 */