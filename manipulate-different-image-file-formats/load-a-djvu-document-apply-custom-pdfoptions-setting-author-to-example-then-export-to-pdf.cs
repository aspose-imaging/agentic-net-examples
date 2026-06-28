using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\result.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with custom author
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Example"
                    }
                };

                // Save as PDF
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
 * 1. When a developer needs to convert archived DjVu scans of historical documents into searchable PDF files while embedding the author's name for proper metadata tracking.
 * 2. When an application must batch‑process DjVu e‑books and generate PDF versions with a custom author field to comply with publishing standards.
 * 3. When a document management system requires converting user‑uploaded DjVu images to PDF and setting the author property to identify the source of the content.
 * 4. When a C# service automates the migration of legacy DjVu technical manuals to PDF format and needs to preserve author information using Aspose.Imaging PdfOptions.
 * 5. When a workflow integrates Aspose.Imaging to transform DjVu graphics into PDF reports and assign a specific author name for audit and compliance purposes.
 */