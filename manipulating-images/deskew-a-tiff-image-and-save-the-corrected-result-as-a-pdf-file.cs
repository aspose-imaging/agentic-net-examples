// HOW-TO: Deskew A TIFF Image And Convert To PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.tif");
        string outputPath = Path.Combine("Output", "deskewed.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    raster.NormalizeAngle(false, Color.White);
                }

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
 * 1. When a developer needs to correct the rotation of scanned TIFF documents before archiving them as searchable PDF files.
 * 2. When an application must automatically straighten misaligned TIFF images from a scanner and output them as PDF reports.
 * 3. When a workflow requires converting batch‑processed TIFF pages with skew into PDF for electronic filing or e‑signature.
 * 4. When integrating Aspose.Imaging into a C# service that prepares deskewed PDFs for downstream OCR processing.
 * 5. When a user wants to programmatically clean up skewed TIFF receipts and save them as compact PDF invoices.
 */
