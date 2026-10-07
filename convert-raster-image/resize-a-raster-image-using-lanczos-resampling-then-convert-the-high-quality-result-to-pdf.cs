// HOW-TO: Resize PNG with Lanczos and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string resizedPath = "resized.png";
            string outputPdfPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = 800;
                int newHeight = 600;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                image.Save(resizedPath);
            }

            using (Image resizedImage = Image.Load(resizedPath))
            {
                var pdfOptions = new PdfOptions();
                resizedImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to generate a high‑resolution PDF thumbnail from a large PNG for web previews.
 * 2. When preparing print‑ready PDFs from user‑uploaded images while preserving quality through Lanczos resampling.
 * 3. When automating batch conversion of product photos to uniformly sized PDFs for an e‑catalog.
 * 4. When creating PDF reports that embed resized screenshots or diagrams without losing detail.
 * 5. When optimizing storage by shrinking raster images and storing the result as a compact PDF document.
 */
