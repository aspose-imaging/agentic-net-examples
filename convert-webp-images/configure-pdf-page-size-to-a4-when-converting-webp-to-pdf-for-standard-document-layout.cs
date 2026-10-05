// HOW-TO: Convert WebP Image to A4 PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.webp";
            string outputPath = "Output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed a WebP graphic into a printable PDF document with standard A4 dimensions for corporate reports.
 * 2. When generating PDF invoices that include product images originally stored as WebP to maintain quality while fitting a standard page layout.
 * 3. When creating e‑books where each chapter starts with a WebP illustration that must be converted to A4‑sized PDF pages automatically.
 * 4. When automating batch conversion of WebP assets to A4 PDFs for archival purposes in a .NET backend service.
 * 5. When developing a web application that receives user‑uploaded WebP files and returns a ready‑to‑print A4 PDF for download.
 */
