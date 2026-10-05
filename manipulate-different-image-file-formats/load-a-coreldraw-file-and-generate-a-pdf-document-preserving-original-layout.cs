// HOW-TO: Convert CorelDRAW CDR to PDF Preserving Layout in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CorelDrawToPdf
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a design team needs to automatically generate printable PDFs from CorelDRAW source files in a .NET backend.
 * 2. When an e‑commerce platform must convert uploaded CDR artwork to PDF for customer preview without losing the original layout.
 * 3. When a document management system stores CDR files and requires on‑the‑fly PDF conversion for viewing in browsers.
 * 4. When a batch‑processing service has to create PDF archives of multiple CorelDRAW drawings while preserving exact positioning and formatting.
 * 5. When a reporting tool integrates vector graphics created in CorelDRAW and needs to embed them as high‑quality PDFs in generated reports.
 */
