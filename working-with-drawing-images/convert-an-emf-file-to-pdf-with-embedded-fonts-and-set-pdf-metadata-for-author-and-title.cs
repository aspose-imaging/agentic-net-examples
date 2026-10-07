// HOW-TO: Convert EMF to PDF with Metadata and Embedded Fonts in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.emf";
        string outputPath = "output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Document Title"
                    }
                };
                emf.Save(outputPath, pdfOptions);
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
 * 1. When a Windows desktop application needs to export vector graphics stored as EMF files into searchable PDF reports that include author and title information.
 * 2. When an automated document generation service must batch‑convert EMF diagrams to PDF while preserving font fidelity and embedding fonts for consistent rendering on any device.
 * 3. When a legal or compliance system requires PDFs generated from EMF charts to contain proper metadata for archiving and audit trails.
 * 4. When a reporting tool built in C# has to create printable PDFs from EMF logos and ensure the PDFs carry the correct author and document title for branding purposes.
 * 5. When a cloud‑based workflow needs to transform user‑uploaded EMF files into PDF format with embedded fonts to avoid missing‑font issues in downstream viewers.
 */
