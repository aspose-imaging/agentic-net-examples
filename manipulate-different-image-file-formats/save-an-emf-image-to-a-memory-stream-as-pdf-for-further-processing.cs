// HOW-TO: Convert EMF to PDF in Memory Stream Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };

                        image.Save(ms, pdfOptions);
                    }

                    Console.WriteLine($"PDF saved to memory stream, size: {ms.Length} bytes.");
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
 * 1. When you need to embed a vector EMF logo into a PDF report without writing intermediate files.
 * 2. When a web service must convert uploaded EMF diagrams to PDF bytes for downstream APIs.
 * 3. When generating PDF invoices that include scalable EMF graphics directly from a C# backend.
 * 4. When processing batch EMF files in memory to create PDF thumbnails for a document management system.
 * 5. When performing server‑side conversion of EMF drawings to PDF for digital signatures without touching the file system.
 */
