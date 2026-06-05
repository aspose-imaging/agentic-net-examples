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
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output\\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Resize all pages to 1024x768 using bilinear resampling
                djvuImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Save the resized document as PDF
                djvuImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert a multi‑page DjVu document of scanned blueprints into a PDF that fits a 1024×768 screen, this C# code resizes each page with bilinear resampling and saves the result.
 * 2. When an application must batch‑process DjVu e‑books for mobile devices, the code loads each DjVu file from a stream, uniformly scales the pages to 1024×768, and outputs a PDF compatible with e‑readers.
 * 3. When a web service receives DjVu files from users and must deliver printable PDFs with consistent page dimensions, the snippet uses Aspose.Imaging to resize and convert the images on the server side.
 * 4. When a document management system archives legacy DjVu scans but requires PDF thumbnails of 1024×768 for preview, this example demonstrates how to programmatically resize and export the pages.
 * 5. When a developer integrates image processing into a C# workflow that standardizes page size before archival, the code loads the DjVu document, applies a 1024×768 resize, and saves it as a PDF using Aspose.Imaging.
 */