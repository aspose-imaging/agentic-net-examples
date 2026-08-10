// HOW-TO: Resize DjVu Pages to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\Result\sample.pdf";

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
                // Resize each page to 1024x768 using Bilinear resampling
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
 * 1. When you need to compress large DjVu documents for web viewing by resizing each page to a standard 1024×768 resolution before creating a PDF version.
 * 2. When an archival system requires DjVu scans to be converted into searchable PDFs with consistent page dimensions for easier indexing.
 * 3. When a printing workflow demands that all pages from a multi‑page DjVu file be uniformly resized to fit a specific paper size prior to PDF generation.
 * 4. When a mobile app must display DjVu content as PDF thumbnails at a fixed resolution to ensure fast loading on devices.
 * 5. When a batch processing script automates the conversion of DjVu manuals into PDF manuals while standardizing page size for consistent layout across all files.
 */
