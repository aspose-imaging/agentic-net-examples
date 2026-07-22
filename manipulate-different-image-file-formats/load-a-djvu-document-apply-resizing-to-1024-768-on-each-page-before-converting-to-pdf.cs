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
        string inputPath = "input\\sample.djvu";
        string outputPath = "output\\result.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Resize each page to 1024x768 using bilinear resampling
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
 * 1. When a developer needs to convert scanned DjVu archives of technical manuals into PDF files that fit a standard 1024×768 display resolution for easier viewing on web browsers.
 * 2. When an application must batch‑process DjVu e‑books, resize each page to a uniform 1024×768 size to reduce file size, and output them as searchable PDF documents.
 * 3. When a document‑management system requires importing legacy DjVu drawings, scaling them to 1024×768 pixels, and storing them as PDF for compatibility with common office tools.
 * 4. When a mobile app needs to display DjVu comic pages at a fixed 1024×768 resolution and then share them as PDF attachments via email.
 * 5. When a cloud service automates the conversion of DjVu blueprints into PDF reports, applying bilinear resampling to maintain image quality at 1024×768 dimensions.
 */