// HOW-TO: Convert ODG to PDF and Set Custom Author in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    pdfOptions.PdfDocumentInfo.Author = "Custom Author";

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
 * 1. When you need to generate a PDF report from an OpenDocument graphics file while embedding the creator’s name for document tracking.
 * 2. When an application must batch‑convert ODG illustrations to PDF for distribution and ensure the author field is set for compliance.
 * 3. When a web service receives user‑uploaded ODG diagrams and must return PDF versions with custom metadata for archival purposes.
 * 4. When automating document workflows that require preserving source author information while converting vector graphics to a portable PDF format.
 * 5. When integrating Aspose.Imaging into a C# project to programmatically add or update PDF metadata during format conversion.
 */
