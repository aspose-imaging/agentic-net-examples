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

            // Open the DjVu file and process each page
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set BMP options with 32 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };

                    // Save the page as BMP
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate high‑color‑depth BMP files for legacy Windows applications.
 * 2. When a document‑management system must convert scanned DjVu files into 32‑bit BMP images to preserve transparency and color fidelity before further processing.
 * 3. When an archival workflow requires batch conversion of DjVu pages to BMP format with 32 bits per pixel to ensure compatibility with image‑editing tools that only accept BMP.
 * 4. When a printing service needs to transform DjVu e‑books into BMP images with full 32‑bit color depth for accurate rasterization on printers that do not support DjVu.
 * 5. When a C# application must programmatically read a DjVu file, iterate over its pages, and save each page as a 32‑bit BMP to embed the images into a .NET reporting engine.
 */