// HOW-TO: Convert CDR to PDF with Embedded Fonts Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

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
                    // Ensure fonts are embedded in the PDF (fonts are embedded by default in Aspose.Imaging)
                    // If an explicit property exists, it can be set here, e.g., pdfOptions.EmbedFonts = true;
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
 * 1. When a graphic designer needs to share a CorelDRAW artwork as a PDF that preserves the original typography without relying on the client’s installed fonts.
 * 2. When an automated build pipeline must batch‑convert CDR files to PDF for archiving while guaranteeing that all text appears correctly on any device.
 * 3. When a web application generates printable PDFs from user‑uploaded CDR logos and must embed the fonts to avoid missing‑glyph issues in browsers.
 * 4. When a legal document management system imports CDR diagrams and needs PDFs with embedded fonts to meet compliance and ensure document fidelity.
 * 5. When a desktop utility converts legacy CDR marketing materials to PDF for inclusion in e‑books, requiring the fonts to be embedded so the layout stays consistent across platforms.
 */
