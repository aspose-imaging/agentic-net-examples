using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.pdf";

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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "John Doe",
                        Title = "Sample PDF"
                    };

                    EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.White,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a Windows desktop application must generate printable PDF reports from vector‑based EMF charts while preserving font fidelity and adding author and title metadata.
 * 2. When an automated document conversion service needs to batch‑process EMF logos into PDF files with embedded fonts for consistent branding across different operating systems.
 * 3. When a legal or compliance system requires converting EMF diagrams to PDF and embedding metadata such as author and title for audit‑trail purposes.
 * 4. When a cloud‑based API transforms user‑uploaded EMF drawings into searchable PDF documents, ensuring the fonts are rasterized correctly and PDF properties are set programmatically in C#.
 * 5. When a legacy engineering tool exports schematics as EMF and a .NET utility must create PDF documentation with proper page size, white background, and PDF metadata for inclusion in technical manuals.
 */