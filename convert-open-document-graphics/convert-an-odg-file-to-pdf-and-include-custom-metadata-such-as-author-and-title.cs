// HOW-TO: Convert ODG to PDF with Custom Author and Title Metadata in C# (Aspose.Imaging for .NET)
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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author",
                        Title = "Custom Title"
                    };
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
 * 1. When a developer needs to generate PDF reports from ODG drawings while embedding the document’s author and title for proper cataloging in a document management system.
 * 2. When an application must batch‑process OpenDocument graphics and produce searchable PDFs that include custom metadata for compliance auditing.
 * 3. When a CAD‑to‑PDF export feature requires preserving source information such as creator name and project title within the PDF’s document properties.
 * 4. When integrating Aspose.Imaging into a workflow that converts user‑uploaded ODG files to PDFs and adds branding metadata before storing them in a cloud repository.
 * 5. When building a C# service that converts design files to PDF and programmatically sets PDF metadata to improve SEO and enable easy retrieval in content‑management platforms.
 */
