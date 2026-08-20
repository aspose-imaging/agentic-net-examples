// HOW-TO: Resize PNG to Max Width and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                const int maxWidth = 1200;

                // Resize only if width exceeds the maximum, preserving aspect ratio
                if (image.Width > maxWidth)
                {
                    int newWidth = maxWidth;
                    int newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);
                    image.Resize(newWidth, newHeight);
                }

                // Convert and save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to shrink large PNG photos to fit web page layouts while preserving their aspect ratio before generating a PDF report.
 * 2. When an automated batch job must ensure uploaded PNGs do not exceed 1200 pixels in width before archiving them as PDF documents.
 * 3. When a desktop application creates printable PDFs from user‑selected PNG images and must resize oversized images to avoid oversized PDF files.
 * 4. When a document‑generation service converts marketing PNG assets into PDF brochures and must limit image width for consistent page design.
 * 5. When a server‑side API receives high‑resolution PNGs, resizes them to a safe width, and returns a PDF version for client download.
 */
