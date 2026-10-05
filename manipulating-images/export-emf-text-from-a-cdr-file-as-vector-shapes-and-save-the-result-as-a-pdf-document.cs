// HOW-TO: Convert CorelDRAW CDR to PDF with Vector Shapes in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a printable PDF from a CorelDRAW design while preserving editable vector graphics.
 * 2. When an application must batch‑convert customer‑provided CDR files to PDF for archiving without rasterizing the artwork.
 * 3. When a web service offers on‑the‑fly preview of CDR drawings in PDF format for browsers that only support PDF viewing.
 * 4. When integrating a document workflow that extracts vector‑based content from CDR files to embed in reports or invoices as scalable graphics.
 * 5. When automating the migration of legacy CorelDRAW assets to a PDF‑based catalog while keeping text as selectable, searchable vector objects.
 */
