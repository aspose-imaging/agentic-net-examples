// HOW-TO: Convert Multi‑Page CDR to PDF with A4 Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.cdr");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 595,
                        PageHeight = 842
                    }
                };
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
 * 1. When a designer needs to export a multi‑page CorelDRAW (CDR) file to a printable A4 PDF for client review.
 * 2. When an automated workflow must batch‑convert CDR drawings into PDF documents that match standard A4 dimensions for archival.
 * 3. When a web service generates PDF reports from CDR templates and must ensure the output fits A4 paper for consistent printing.
 * 4. When integrating Aspose.Imaging into a C# application to produce A4‑sized PDFs for legal documents derived from vector graphics.
 * 5. When a desktop utility needs to preserve the original layout while converting CDR pages to PDF with a fixed A4 page size for e‑learning materials.
 */
