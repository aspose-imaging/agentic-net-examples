// HOW-TO: Resize BMP Image With Nearest Neighbor And Convert To PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPdfPath = "output\\resized.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the BMP image
            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                // Define new dimensions (example: half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using nearest‑neighbor interpolation (default or explicit)
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to shrink a large BMP graphic for faster loading in a PDF report without smoothing the pixels.
 * 2. When generating printable PDFs from legacy BMP assets while preserving the original pixelated style for retro game documentation.
 * 3. When automating a batch process that converts high‑resolution BMP scans into smaller PDF files for email attachment size limits.
 * 4. When creating thumbnails of BMP images inside a PDF catalog where exact pixel mapping is required for accurate layout.
 * 5. When integrating Aspose.Imaging in a C# application to resize BMP icons and embed them directly into PDF invoices.
 */
